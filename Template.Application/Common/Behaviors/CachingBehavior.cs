using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Application.Features.Interface;
using Template.Domain.Interfaces;

namespace Template.Application.Common.Behaviors
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : ICacheable
    {

        private readonly ICacheService _cache;
        public CachingBehavior(ICacheService cache)
          => _cache = cache;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {

            var cached = await _cache.GetAsync<TResponse>(request.CacheKey);
            if (cached is not null) return cached;

            var response = await next();

            await _cache.SetAsync(request.CacheKey, response, request.CacheDuration);

            return response;
        }
    }

}
