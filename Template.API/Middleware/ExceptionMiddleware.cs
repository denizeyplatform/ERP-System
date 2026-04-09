using Template.Application.Common;

namespace Template.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Unhandled exception occurred. Path: {Path}",
                    context.Request.Path);

                context.Response.StatusCode = 500;

                var response = GlobalApiResponse<string>
                    .FailureResponse("Internal Server Error");

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
