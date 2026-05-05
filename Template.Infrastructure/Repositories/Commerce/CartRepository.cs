using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

namespace Template.Infrastructure.Repositories.Commerce;

    public class CartRepository : ICartRepository
{
        private readonly StackExchange.Redis.IDatabase _redis;
        private readonly IHttpContextAccessor _ctxAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository productRepository;

        public CartRepository(IConnectionMultiplexer redis, 
            IHttpContextAccessor ctxAccessor,
            IUnitOfWork unitOfWork, 
            IProductRepository _productRepository)
        {
            _redis = redis.GetDatabase();
            _ctxAccessor = ctxAccessor;
            _unitOfWork = unitOfWork;
            productRepository = _productRepository;
        }

        public string GetCartOwnerId()
        {
            var context = _ctxAccessor.HttpContext
                     ?? throw new InvalidOperationException("No HTTP context");

            var isAuthenticated = _ctxAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated)
            {
                return _ctxAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? throw new Exception("Authenticated user has no ID claim");
            }

            // Ensure session is enabled
            if (string.IsNullOrEmpty(_ctxAccessor.HttpContext.Session.Id))
                throw new Exception("Session not available");

            //return $"guest:{_ctxAccessor.HttpContext.Session.Id}";
            return GetCartKey("b6a7f0b3-67dc-2f96-c971-d0cd17a99373");
        }

        private string GetCartKey(string userId) => $"cart:user:{userId}";

        public async Task<Cart> AddItemAsync(CartItem item)
        {
            string userId = GetCartOwnerId();
            var key = GetCartKey(userId);
            Cart cart;

            var existingData = await _redis.StringGetAsync(key);
            if (!existingData.HasValue)
            {
                cart = new Cart { UserId = userId };
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(existingData!) ?? new Cart { UserId = userId };
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }

            await _redis.StringSetAsync(key, JsonConvert.SerializeObject(cart), TimeSpan.FromSeconds(60));
            return cart;
        }
        public async Task<Cart> GetCartAsync()
        {
            string userId = GetCartOwnerId();
            var key = GetCartKey(userId);
            var data = await _redis.StringGetAsync(key);

            if (!data.HasValue)
                return new Cart { UserId = userId };

            var cart = JsonConvert.DeserializeObject<Cart>(data!)
                       ?? new Cart { UserId = userId };

            return cart;
        }

        public async Task<Cart> UpdateProductQuantityAsync(Guid ProductId, int Quantity)
        {
            string userId = GetCartOwnerId();

            var key = GetCartKey(userId);

            var cart = await GetCartAsync();

            var item = cart.Items.FirstOrDefault(x => x.ProductId == ProductId);
            if (item != null)
            {
                if (Quantity > 0)
                {
                    item.Quantity = Quantity;
                }
                else
                {
                    // Remove item if quantity is 0 or less
                    cart.Items.Remove(item);
                }

                var updatedCartJson = JsonConvert.SerializeObject(cart);
                await _redis.StringSetAsync(key, updatedCartJson, TimeSpan.FromSeconds(60));

            }

            return cart;
        }


    public async Task<Cart> RemoveItemAsync(Guid productId)
    {
        string userId = GetCartOwnerId();
        var carts = await GetCartAsync();
        var updatedCart = carts.Items.Where(x => x.ProductId != productId).ToList();
        carts.Items = updatedCart;
        if (carts.Items.Count > 0)
        {
            await _redis.StringSetAsync(GetCartKey(userId), JsonConvert.SerializeObject(carts), TimeSpan.FromSeconds(60));
        }
        else
        {
            await ClearCartAsync();
        }
        return carts;
    }

    public async Task ClearCartAsync()
        {
            string userId = GetCartOwnerId();
            await _redis.KeyDeleteAsync(GetCartKey(userId));
        }


}

