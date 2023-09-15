using System;
using Microsoft.Extensions.Caching.Memory;

namespace CacheMemory
{
	public static class CacheModel
	{
		private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

		public static void Add(CacheDto cache)
		{
			var cacheExpirationOptions = new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds(120),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromSeconds(100)
			};
			_memoryCache.Set(cache.Email, cache, cacheExpirationOptions);
		}

        public static object Get(string email)
        {
             return _memoryCache.Get(email);
        }

		public static void Remove(string valueKey)
		{
			_memoryCache.Remove(valueKey);
		}
    }
}

