using Serilog.Context;

namespace Template.API.Middleware
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderKey = "X-Correlation-ID";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var correlationId = context.Request.Headers[HeaderKey]
                .FirstOrDefault() ?? Guid.NewGuid().ToString();

            context.Items[HeaderKey] = correlationId;

             context.Response.Headers.Add(HeaderKey, correlationId);

            using (LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next(context);
            }
        }
    }
}
