using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using Peep.Wings.Domain.Entities;
using Peep.Wings.Application.ViewModels;

namespace Peep.Wings.Application.Controllers
{
    public abstract class CustomControllerBase : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ConnectionFactory _factory;
        private const string QUEUE_NAME = "wings_messages";

        public CustomControllerBase(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;

            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public abstract Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email);

        protected ApplicationUserViewModel LoggedUser =>
            HttpContext.User.Identity.IsAuthenticated
                ? new ApplicationUserViewModel
                {
                    Id = Guid.Parse(HttpContext.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Username = HttpContext.User.Claims.First(c => c.Type == "UserName").Value,
                    Email = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value,
                    AuthenticationMethod = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.AuthenticationMethod)?.Value
                }
                : null;

        protected async Task<ApplicationUser> GetAuthenticatedUserAccount()
            => await _userManager.Users.FirstOrDefaultAsync(u => u.Id == LoggedUser.Id);

        protected AcceptedResult PostCreatedAccountMessage(ApplicationUserViewModel user)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: QUEUE_NAME,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var stringfiedMessage = JsonSerializer.Serialize(user);
            var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

            channel.BasicPublish(
                exchange: "",
                routingKey: QUEUE_NAME,
                basicProperties: null,
                body: bytesMessage);

            return Accepted();
        }
    }
}
