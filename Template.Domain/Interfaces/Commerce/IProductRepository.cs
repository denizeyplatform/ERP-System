using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;

namespace Template.Domain.Interfaces.Commerce
{
    public interface IProductRepository : IRepository<Product>
    {
        Task CreateProduct(Product product);
        Task<Dictionary<Guid, Product>> getProductsByIds(List<Guid> productIds);
    }
}
