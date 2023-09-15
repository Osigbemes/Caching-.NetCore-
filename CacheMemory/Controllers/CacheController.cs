using System;
using Microsoft.AspNetCore.Mvc;

namespace CacheMemory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CacheController : ControllerBase
    {
		public CacheController()
		{
		}

        [HttpPost]
        public IActionResult CreateCache(CacheDto cache)
        {
            CacheModel.Add(cache.ValueKey, cache.Key);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveCache(CacheDto cache)
        {
            CacheModel.Remove(cache.ValueKey);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCache(CacheDto cache)
        {
            CacheModel.Get(cache.ValueKey);
            return Ok();
        }
    }
}

