using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;
using Template.Application.Features.Interface;
using Template.Domain.Entities.Commerce;

namespace Template.Application.Features.Service.Commerce
{
    public class CartService : ICartService
    {
        public Task<Cart> AddItemAsync(CartItem item)
        {
            throw new NotImplementedException();
        }

        public Task<Order> CheckoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task ClearCartAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCartAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> RemoveItemAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateProductQuantityAsync(UpdateCartDto UpdateCartDto)
        {
            throw new NotImplementedException();
        }
    }
}
