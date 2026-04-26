using Serilog; 
using Serilog.Events; 
using Serilog.Sinks;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File; // For File sink and RollingInterval
using Serilog.AspNetCore; // Add this using directive
using Template.API.Configuration;
using Template.API.Exceptions.Handler;
using Template.API.Middleware;
using Template.Application.Common.Behaviors;
using Template.Application.Configuration;
using Template.Infrastructure.Configuration; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Logging
LoggingConfiguration.ConfigureLogging(builder);

// Telemetry
OpenTelemetryConfiguration.ConfigureTelemetry(builder.Services);




builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    config.AddOpenBehavior(typeof(PerformanceBehavior<,>));
    config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
});
builder.Services.AddAPI();

builder.Services.AddApplication();
builder.Services.AddJWTConfig();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityConfig();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Host.UseSerilog();



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
//app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

// Prometheus endpoint
//app.MapPrometheusScrapingEndpoint();
////app.UseSerilogRequestLogging();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.Run();
