using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Peep.Parrot.Domain.Dtos;
using Peep.Parrot.Domain.Repository;
using Peep.Parrot.Domain.ViewModels;

namespace Peep.Parrot.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersInfoController : ControllerBase
    {
        private readonly IDistributedCache _cache;
        private readonly IUserInfoRepository _userInfoRepository;

        public UsersInfoController(
            IDistributedCache cache,
            IUserInfoRepository userInfoRepository)
        {
            this._cache = cache;
            this._userInfoRepository = userInfoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            var cacheKey = $"cache_user:{id}";
            var cache = await _cache.GetStringAsync(cacheKey);
            UserInfoViewModel userInfo;

            if (cache != null)
            {
                userInfo = JsonSerializer.Deserialize<UserInfoViewModel>(cache);
            }
            else
            {
                userInfo = await _userInfoRepository.GetUserInfo(id);
                cache = JsonSerializer.Serialize<UserInfoViewModel>(userInfo);
                await _cache.SetStringAsync(cacheKey, cache);
            }

            return Ok(userInfo);

        }

        [HttpPost]
        public async Task<IActionResult> AddUserInfo(AddUserInfoDto addUserInfoDto)
        {
            if (String.IsNullOrEmpty(addUserInfoDto.Id.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (_userInfoRepository.AddUserInfo(addUserInfoDto))
            {
                var cacheKey = $"cache_user:{addUserInfoDto.Id}";
                var userInfo = await _userInfoRepository.GetUserInfo(addUserInfoDto.Id);
                var cache = JsonSerializer.Serialize<UserInfoViewModel>(userInfo);
                await _cache.SetStringAsync(cacheKey, cache);
                return Ok(userInfo);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfoDto updateUserInfoDto)
        {
            if (String.IsNullOrEmpty(updateUserInfoDto.Id.ToString()))
                return BadRequest( new { Message = "User Id not specified" });

            if (_userInfoRepository.UpdateUserInfo(updateUserInfoDto))
            {
                var cacheKey = $"cache_user:{updateUserInfoDto.Id}";
                var userInfo = await _userInfoRepository.GetUserInfo(updateUserInfoDto.Id);
                var cache = JsonSerializer.Serialize<UserInfoViewModel>(userInfo);
                await _cache.SetStringAsync(cacheKey, cache);
                return NoContent();
            }
               
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserInfo([FromQuery] Guid id)
        {
            if (String.IsNullOrEmpty(id.ToString()))
                return BadRequest(new { Message = "User Id not specified" });

            if (await _userInfoRepository.DeleteUserInfo(id))
            {
                await _cache.RemoveAsync($"cache_user:{id}");
                return NoContent();
            }
                
            return BadRequest();
        }
        
    }
}
