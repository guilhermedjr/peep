using Peep.Wings.Domain.Entities;

namespace Peep.Wings.Domain.Services
{
    public interface ITokenService
    {
        string GenerateJsonWebToken(ApplicationUser user);
    }
}
