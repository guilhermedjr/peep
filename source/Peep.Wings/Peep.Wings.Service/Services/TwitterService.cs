using System.Net.Http.Headers;

namespace Peep.Wings.Service.Services;

public class TwitterService : IOAuthService<TwitterUserInfo>
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private const string Url = "https://api.twitter.com/2";

    public TwitterService(
        HttpClient httpClient, 
        IConfiguration config)
    {
        this._httpClient = httpClient;
        this._config = config;
        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _config["Twitter:BearerToken"]);
    }

    public async Task<TwitterUserInfo> RetrieveLoggedUserInformation(string username)
    {
        var httpResponse = 
            await _httpClient.GetAsync($"{Url}/users/by/username/{username}?user.fields=description,profile_image_url");

        var content = await httpResponse.Content.ReadAsStreamAsync();

        var json = await JsonSerializer.DeserializeAsync<TwitterUserInfo>(content);
        return json;
    }
}

