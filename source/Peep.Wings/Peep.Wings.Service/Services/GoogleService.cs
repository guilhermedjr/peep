namespace Peep.Wings.Service.Services;

public class GoogleService : IOAuthService<GoogleUserInfoDto>
{
    private readonly HttpClient _httpClient;
    private const string Url = "https://www.googleapis.com/oauth2/v3";
 
    public GoogleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<GoogleUserInfoDto> RetrieveLoggedUserInformation(string token)
    {
        throw new NotImplementedException();
    }
}

