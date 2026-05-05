using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;
using Template.Domain.Interfaces;
using Template.Domain.Interfaces.Commerce;
using Template.Infrastructure.Persistance.Data;
using Order = Template.Domain.Entities.Commerce.Order;

namespace Template.Infrastructure.Repositories.Commerce
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StackExchange.Redis.IDatabase _redis;
        public readonly ApplicationDBContext _dbContext;
        private readonly IProductRepository productRepository;
        private readonly ICartRepository cartRepository;

        public OrderRepository(ApplicationDBContext context,
            IConnectionMultiplexer redis, 
            IProductRepository _productRepository, 
            ICartRepository _cartRepository)
        {
            _redis = redis.GetDatabase();
            cartRepository = _cartRepository;
            _dbContext = context;
            productRepository = _productRepository;
        }

        public async Task<object> createOrder(Order order)
        {
            var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();  

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return transaction;
        }

        public async Task<Order> CheckoutAsync()
        {
            // Step 1: Load Cart
            // Step 2: Load Products From DB
            // Step 3: Validate Stock
            // Step 4: Deduct Stock
            // Step 5: Create Order Object
            // Step 6: Save to DB with Transaction
            // Step 7: Clear Redis Cart
            // add enum to order status
            // Step 8: Return Order Confirmation email (optional)

            var userId = cartRepository.GetCartOwnerId();

            // Step 1: Load Cart
            var cart = await cartRepository.GetCartAsync();
            if (cart.Items == null || !cart.Items.Any())
                throw new InvalidOperationException("Cart is empty.");

            // Step 2: Load Products From DB
            var productIds = cart.Items.Select(i => i.ProductId).ToList();
            Dictionary<Guid, Product> products = await productRepository.getProductsByIds(productIds);


            // Step 3: Validate Stock
            foreach (var item in cart.Items)
            {
                if (!products.ContainsKey(item.ProductId))
                    throw new InvalidOperationException($"Product '{item.ProductId}' not found.");

                var product = products[item.ProductId];

                if (item.Quantity > product.Quantity)
                    throw new InvalidOperationException(
                        $"Insufficient stock for '{product.Name}'. Available: {product.Quantity}, Requested: {item.Quantity}"
                    );

                // Step 4: Deduct Stock
                product.Quantity -= item.Quantity;

            }


            // Step 5: Create Order Object
            var order = new Domain.Entities.Commerce.Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.Total,
                Items = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            // Step 6: Save to DB with Transaction
            await createOrder(order);

            // Step 7: Clear Redis Cart
            await _redis.KeyDeleteAsync(userId);

            return order;


        }

        // add enum to order status

    }
}
