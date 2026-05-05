using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Interfaces;
using Template.Domain.Interfaces.Commerce;
using Template.Domain.Interfaces.HRM;
using Template.Infrastructure.Persistance.Data;
using Template.Infrastructure.Repositories;
using Template.Infrastructure.Repositories.Commerce;
using Template.Infrastructure.Repositories.HRM;
using Template.Infrastructure.Services.CacheService;

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

            // HRM Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Commerce
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();



            AddRedisConfig(services, configuration);
            AddIdentityConfig(services);

            return services;
        }

        public static IServiceCollection AddRedisConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMemoryCache();

            services.Configure<RedisSettings>(
                configuration.GetSection("Redis"));

            var redisConnection =
                configuration["Redis:ConnectionString"];

            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(redisConnection!));

            services.AddScoped<ICacheService, RedisCacheService>();

            return services;
        }

        public static IServiceCollection AddIdentityConfig(this IServiceCollection services)
        {
           

            
            return services;
        }
    }
}
