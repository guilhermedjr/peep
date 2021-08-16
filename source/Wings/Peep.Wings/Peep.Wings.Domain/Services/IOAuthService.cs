using System.Threading.Tasks;

namespace Peep.Wings.Domain.Services
{
    public interface IOAuthService
    {
        Task RetrieveLoggedUserInformation(string userIdentifier);
    }
}
