namespace Peep.Wings.Service.Services;

public class GoogleService : IOAuthService<GoogleUserInfoDto>
{
    private readonly HttpClient _httpClient;
    private string Url = "https://www.googleapis.com/oauth2/v3/userinfo?alt=json";
 
    public GoogleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GoogleUserInfoDto> RetrieveLoggedUserInformation(string token)
    {
        var requestMessage = new HttpRequestMessage(HttpMethod.Get, Url);
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var httpResponse = await _httpClient.SendAsync(requestMessage);
        string responseData = await httpResponse.Content.ReadAsStringAsync();

        var googleUserInfo = JsonSerializer.Deserialize<GoogleUserInfoDto>(responseData);
        return googleUserInfo;
    }
}

