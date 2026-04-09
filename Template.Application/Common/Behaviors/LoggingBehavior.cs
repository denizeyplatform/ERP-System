using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken ct)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation($"Handling {requestName}");
            _logger.LogInformation($"Request Data: {@request}");

            var response = await next();

            _logger.LogInformation($"Handled {requestName}");
            _logger.LogInformation($"Response Data: {@response}");

            return response;
        }
    }
}
