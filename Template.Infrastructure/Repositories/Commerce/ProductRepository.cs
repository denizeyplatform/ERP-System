using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Entities.Commerce;
using Template.Domain.Interfaces.Commerce;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories.Commerce
{
    public class ProductRepository(ApplicationDBContext _dbContext) : Repository<Product>(_dbContext) , IProductRepository
    {
        private readonly ApplicationDBContext _dbContext = _dbContext;

        public async Task CreateProduct(Product product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<Dictionary<Guid, Product>> getProductsByIds(List<Guid> productIds)
        {
            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id);
            return products;
        }
    }
}
