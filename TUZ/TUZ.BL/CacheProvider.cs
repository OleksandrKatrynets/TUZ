using System;
using Microsoft.Extensions.Caching.Memory;

namespace TUZ.BL
{
    public class CacheProvider
    {
        private readonly IMemoryCache _cache;

        public CacheProvider()
        {
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public void Set<T>(string key, T value, DateTimeOffset absoluteExpiry)
            => _cache.Set(key, value, absoluteExpiry);

        public T Get<T>(string key)
            => _cache.TryGetValue(key, out T value) ? value : default(T);
    }
}
