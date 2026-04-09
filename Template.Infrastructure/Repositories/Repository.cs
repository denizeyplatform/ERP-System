using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;
using Template.Domain.Interfaces;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDBContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.SoftDelete();
            _dbSet.Update(entity);
        }
    }
}
