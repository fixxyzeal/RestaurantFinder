using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        public CacheService(IMemoryCache cache, IConfiguration configuration)
        {
            _cache = cache;
            _configuration = configuration;
        }

        // Get value from cache
        public async Task<T> GetMemoryCache<T>(string key)
        {
            object result = _cache.Get(key.ToLower());

            return await Task.Run(() => (T)result).ConfigureAwait(false);
        }

        public async Task<T> SetMemoryCache<T>(string key, T value)
        {
            // Set value to Cache
            await _cache.GetOrCreateAsync(key.ToLower(), entry =>
            {
                //Get Cache Expiration from Appsettings.json
                entry.SlidingExpiration = TimeSpan.FromSeconds(double.Parse(_configuration["CacheLifeTime"]));
                return Task.FromResult(value);
            }).ConfigureAwait(false);

            return value;
        }
    }
}