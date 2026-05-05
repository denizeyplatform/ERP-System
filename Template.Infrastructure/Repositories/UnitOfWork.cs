using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;
using Template.Domain.Interfaces;
using Template.Domain.Interfaces.HRM;
using Template.Infrastructure.Persistance.Data;

namespace Template.Infrastructure.Repositories
{
    public class UnitOfWork(
        ApplicationDBContext context,
        ILogger<UnitOfWork> logger,
        IHttpContextAccessor httpContextAccessor) : IUnitOfWork
    {
        private readonly ApplicationDBContext _context = context;
        private readonly ILogger<UnitOfWork> _logger = logger;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public IEmployeeRepository? EmployeeRepository { get; set; } 
        public IAttendanceRepository? AttendanceRepository { get; set; }

        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }
        public async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            try
            {
                var userId = _httpContextAccessor
                    .HttpContext?
                    .User?
                    .Identity?
                    .Name ?? "System";

                foreach (var entry in _context.ChangeTracker
                    .Entries<BaseEntity>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedAt = DateTime.UtcNow;
                            entry.Entity.CreatedBy = userId;
                            break;

                        case EntityState.Modified:
                            entry.Entity.ModifiedAt = DateTime.UtcNow;
                            entry.Entity.ModifiedBy = userId;
                            break;
                    }
                }

                _logger.LogInformation(
                    "Committing transaction by user {User}",
                    userId);

                var result = await _context
                    .SaveChangesAsync(cancellationToken);

                _logger.LogInformation(
                    "Transaction committed successfully. Rows affected: {Count}",
                    result);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Error occurred during transaction commit");

                throw;
            }
        }

      
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
