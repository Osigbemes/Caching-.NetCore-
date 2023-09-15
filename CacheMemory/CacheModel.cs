﻿using System;
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
				AbsoluteExpiration = DateTime.Now.AddSeconds(50),
				Priority = CacheItemPriority.High,
				SlidingExpiration = TimeSpan.FromSeconds(20)
			};
			_memoryCache.Set(cache.Email, cache, cacheExpirationOptions);
		}

        public static object Get(string email)
        {
             var cache = _memoryCache.Get(email);
			return cache;
        }

		public static void Remove(string valueKey)
		{
			_memoryCache.Remove(valueKey);
		}
    }
}

