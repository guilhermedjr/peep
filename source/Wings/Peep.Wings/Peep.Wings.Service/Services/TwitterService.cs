using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Peep.Wings.Domain.Services;

namespace Peep.Wings.Service.Services
{
    public class TwitterService : IOAuthService
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

        public async Task RetrieveLoggedUserInformation(string username)
        {
            var httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{Url}/users/by/username/{username}"),
                Method = HttpMethod.Get
            };
            httpRequest.Headers.Add("user.fields", "description,profile_image_url");

            var httpResponse = await _httpClient.SendAsync(httpRequest);
            //return httpResponse.Content;
        }
    }
}
