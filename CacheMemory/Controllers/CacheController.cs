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
        public ActionResult CreateCache(CacheDto cache)
        {
            CacheModel.Add(cache);
            return Ok();
        }

        [HttpDelete]
        public ActionResult RemoveCache(CacheDto cache)
        {
            CacheModel.Remove(cache.Email);
            return Ok();
        }

        [HttpGet]
        public ActionResult<CacheDto> GetCache(CacheDto cache)
        {
            return Ok(CacheModel.Get(cache.Email));
        }
    }
}

