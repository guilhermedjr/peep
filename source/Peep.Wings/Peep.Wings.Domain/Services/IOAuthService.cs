namespace Peep.Wings.Domain.Services;

public interface IOAuthService<T> where T : class
{
    Task<T> RetrieveLoggedUserInformation(string token);
}

