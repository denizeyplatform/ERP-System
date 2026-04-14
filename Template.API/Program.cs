using Serilog;
using Serilog; // For Serilog types
using Serilog.Events;
using Serilog.Events; // For LogEventLevel
using Serilog.Sinks;
using Serilog.Sinks.File;
using Serilog.Sinks.File; // For File sink and RollingInterval
using Template.API.Configuration;
using Template.API.Exceptions.Handler;
using Template.API.Middleware;
using Template.Application.Configuration;
using Template.Infrastructure.Configuration; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddAPI();



builder.Services.AddApplication();
builder.Services.AddJWTConfig();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddIdentityConfig();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .WriteTo.Console()
    .WriteTo.File(
        "logs/log-.txt",
        rollingInterval: RollingInterval.Day, 
        retainedFileCountLimit: 30)
    .CreateLogger();
builder.WebHost.UseSerilog();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<CorrelationIdMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();
app.UseExceptionHandler();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.Run();
