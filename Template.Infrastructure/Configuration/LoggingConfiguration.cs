using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Infrastructure.Configuration
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging(WebApplicationBuilder builder)
        {
            var env = builder.Environment.EnvironmentName;
            var elasticUri = builder.Configuration["Elastic:Uri"];

            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Environment", env)
                .Enrich.WithThreadId()
                .Enrich.WithProcessId()
                .WriteTo.Console()
                .WriteTo.File(
                    "logs/erplog-.txt",
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30);




            if (!string.IsNullOrWhiteSpace(elasticUri))
            {
                try
                {
                    loggerConfig.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = $"ERPSystemlogs-{env.ToLower()}-{DateTime.UtcNow:yyyy-MM}"
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Elasticsearch sink failed: {ex.Message}");
                }
            }

            Log.Logger = loggerConfig.CreateLogger();

        }
    }
}
