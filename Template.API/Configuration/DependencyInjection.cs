using Microsoft.Extensions.Configuration;


namespace Template.API.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }

  
}
