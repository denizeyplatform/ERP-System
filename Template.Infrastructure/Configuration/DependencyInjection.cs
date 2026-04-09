using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces;
using Template.Infrastructure.Persistance.Data;
using Template.Infrastructure.Repositories;

namespace Template.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();



            services.AddMemoryCache();

            //services.AddScoped<ICacheService, MemoryCacheService>();

            return services;
        }


        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppDbContext>();

            
            return services;
        }
    }
}
