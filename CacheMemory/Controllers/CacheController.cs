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
            return Ok($"Cache added with key {cache.Email}");
        }

        [HttpDelete("{email}")]
        public ActionResult RemoveCache(string email)
        {
            CacheModel.Remove(email);
            return Ok();
        }

        [HttpGet("{email}")]
        public ActionResult<CacheDto> GetCache(string email)
        {
            return Ok(CacheModel.Get(email));
        }
    }
}

