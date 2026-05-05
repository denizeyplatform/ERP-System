using StackExchange.Redis;

namespace Template.API.Middleware
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConnectionMultiplexer _redis;
        private const int Limit = 10;

        public RateLimitMiddleware(RequestDelegate next,IConnectionMultiplexer redis)
        {
            _next = next; 
            _redis = redis;
        }

        public async Task InvokeAsync(HttpContext ctx)
        {
            var ip = ctx.Connection.RemoteIpAddress;
            var key = $"rate:{ip}:{ctx.Request.Path}";
            var db = _redis.GetDatabase();

            // Atomic pipeline: INCR + EXPIRE
            var batch = db.CreateBatch();
            var inc = batch.StringIncrementAsync(key);
            var exp = batch.KeyExpireAsync(key,TimeSpan.FromMinutes(60));
            batch.Execute();

            var count = await inc;
            if (count > Limit)
            {
                ctx.Response.StatusCode = 429;
                ctx.Response.Headers["Retry-After"] = "60";
                await ctx.Response.WriteAsync("Rate limit exceeded. Try after 60 Min.");
                return;
            }
            await _next(ctx);
        }
    }

}
