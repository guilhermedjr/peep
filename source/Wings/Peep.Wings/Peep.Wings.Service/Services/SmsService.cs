using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Peep.Wings.Domain.Services;

namespace Peep.Wings.Service.Services
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _config;

        public SmsService(IConfiguration config)
        {
            this._config = config;
        }

        public Task SendSMS(string phoneNumber, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
