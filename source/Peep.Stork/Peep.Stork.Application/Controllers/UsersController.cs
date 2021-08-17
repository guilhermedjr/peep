using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Peep.Stork.Domain.Dtos.Users;
using Peep.Stork.Domain.Entities;

namespace Peep.Stork.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        /// <summary>
        ///  Add a user already registered in the Wings db in the local database.
        /// </summary>
        /// <param name="syncUserDto"></param>
        /// <remarks>This endpoint is accessed directly by the Wings API, and should not be accessed otherwise.</remarks>
        [HttpPost]
        public async Task AddUser(SyncUserDto syncUserDto)
        {
            var user = new ApplicationUser
            {
                Id = syncUserDto.Id,
                Name = syncUserDto.Name,
                Email = !String.IsNullOrEmpty(syncUserDto.Email) ? syncUserDto.Email : null,
                PhoneNumber = !String.IsNullOrEmpty(syncUserDto.PhoneNumber) ? syncUserDto.PhoneNumber : null,
                BirthDate = syncUserDto.BirthDate,
                UserName = syncUserDto.Username,
                Password = syncUserDto.Password,
                JoinedAt = DateTime.Now

            };

            await _userManager.CreateAsync(user, syncUserDto.Password);
        }

        /// <summary>
        ///  Updates a user in the local database, after its successful update in the Wings db.
        /// </summary>
        /// <param name="syncUserDto"></param>
        /// <remarks>This endpoint is accessed directly by the Wings API, and should not be accessed otherwise.</remarks>
        [HttpPut]
        public async Task UpdateUser(SyncUserDto syncUserDto)
        {
            var user = await _userManager.FindByIdAsync(syncUserDto.Id.ToString());

            user.Name = syncUserDto.Name;
            user.UserName = syncUserDto.Username;
            user.Email = syncUserDto.Email;
            user.PhoneNumber = syncUserDto.PhoneNumber;
            user.Password = syncUserDto.Password;

            await _userManager.UpdateAsync(user);
            
        }
    }
}
