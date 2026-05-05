using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.DTO;
using Template.Domain.Entities.Commerce;

namespace Template.Application.Features.Interface
{
    public interface ICartService
    {
        Task<Cart> AddItemAsync(CartItem item);
        Task<Cart> GetCartAsync();
        Task<Cart> UpdateProductQuantityAsync(UpdateCartDto UpdateCartDto);

        Task ClearCartAsync();
        Task<Cart> RemoveItemAsync(int productId);
        Task<Order> CheckoutAsync();
    }
}
