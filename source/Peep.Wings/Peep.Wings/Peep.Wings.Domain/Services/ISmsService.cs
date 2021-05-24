using System.Threading.Tasks;

namespace Peep.Wings.Domain.Services
{
    public interface ISmsService
    {
        Task SendSMS(string phoneNumber, string message);
    }
}
