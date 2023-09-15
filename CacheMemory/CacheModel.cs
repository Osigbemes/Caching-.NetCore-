using System;
using Microsoft.Extensions.Caching.Memory;

namespace CacheMemory
{
	public static class CacheModel
	{
		private static IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

		public static void Add(string valueKey, int key)
		{
			var cacheExpirationOptions = new MemoryCacheEntryOptions()
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds(50),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromSeconds(20)
			};
			_memoryCache.Set(valueKey, cacheExpirationOptions);
		}

        public static int Get(string valueKey)
        {
            var cacheMemory = _memoryCache.Get(valueKey);
			return Convert.ToInt32(cacheMemory);
        }

		public static void Remove(string valueKey)
		{
			_memoryCache.Remove(valueKey);
		}
    }
}

