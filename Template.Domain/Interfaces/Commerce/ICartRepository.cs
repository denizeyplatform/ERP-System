using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;

namespace Template.Domain.Interfaces.Commerce
{
    public interface ICartRepository
    {
        string GetCartOwnerId();
        Task<Cart> AddItemAsync(CartItem item);
        Task<Cart> GetCartAsync();
        Task<Cart> UpdateProductQuantityAsync(Guid ProductId, int Quantity);

        Task ClearCartAsync();
        Task<Cart> RemoveItemAsync(Guid productId);



    }
}
