using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Application.ViewModels;

namespace Peep.Wings.Application.Controllers
{
    public abstract class CustomControllerBase : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomControllerBase(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        protected ApplicationUserViewModel LoggedUser =>
            HttpContext.User.Identity.IsAuthenticated
                ? new ApplicationUserViewModel
                {
                    Id = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Username = HttpContext.User.Claims.First(c => c.Type == "UserName").Value,
                    Name = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Name).Value
                }
                : null;

        protected async Task<ApplicationUser> GetAuthenticatedUserAccount()
            => await _userManager.Users.FirstOrDefaultAsync(u => u.Id == LoggedUser.Id);

    }
}
