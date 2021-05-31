using System.Threading.Tasks;

namespace Peep.Wings.Domain.Services
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string body, bool isHTML = true);
    }
}
