using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Application.Automapper;
using Template.Application.Common.Behaviors;
using Template.Application.Common.Interfaces;
using Template.Application.Common.Validations.Attendance;
using Template.Application.Common.Validations.Employee;
using Template.Application.CQRS.Employee.Command;
using Template.Application.Features.Service;
using Template.Application.Features.Service.Employee;

namespace Template.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));


            services.AddValidatorsFromAssembly(typeof(CreateEmployeeValidator).Assembly);

            services.AddValidatorsFromAssembly(typeof(CheckInAtendanceValidator).Assembly);

            services.AddAutoMapper(cfg => { }, typeof(EmployeeProfile).Assembly);


            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();


            return services;
        }


        public static IServiceCollection AddJWTConfig(this IServiceCollection services)
        {
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer();

            return services;
        }
    }
}
