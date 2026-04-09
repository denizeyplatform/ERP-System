namespace Template.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var user = context.User?.Identity?.Name ?? "Anonymous";

            _logger.LogInformation(
                "HTTP {Method} {Path} by {User}",
                context.Request.Method,
                context.Request.Path,
                user);

            await _next(context);
        }
    }
}
