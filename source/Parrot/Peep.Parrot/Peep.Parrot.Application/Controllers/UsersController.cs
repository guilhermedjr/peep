using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Peep.Parrot.Domain.Entities;

namespace Peep.Parrot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDistributedCache _cache;

        public UsersController(
            IDistributedCache cache)
        {
            this._cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string id)
        {
            if (String.IsNullOrEmpty(id))
                return BadRequest();

            var cacheKey = $"cache_user:{id}";
            var cache = await _cache.GetStringAsync(cacheKey);
            User user;

            if (cache != null)
            {
                user = JsonSerializer.Deserialize<User>(cache);
            }
            else
            {
                // buscar infos do usuário na base Redis com a key 'user:{id}'
                user = new User
                {
                    Id = Guid.Parse("d952947a-a105-4a0a-bdd4-5c0a3236bc04"),
                    Name = "nome mostrado no perfil",
                    Username = "username",
                    Bio = "bio",
                    Location = "localização",
                    Website = "website"

                };
                cache = JsonSerializer.Serialize<User>(user);
                await _cache.SetStringAsync(cacheKey, cache);
            }

            return Ok(user);

        }
        
    }
}
