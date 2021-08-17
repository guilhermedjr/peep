using System;
using System.Threading.Tasks;
using System.Net.Http;
using Peep.Wings.Domain.Services;
using Peep.Wings.Domain.Dtos;

namespace Peep.Wings.Service.Services
{
    public class GitHubService : IOAuthService<GitHubUserInfo>
    {
        private readonly HttpClient _httpClient;
        private const string Url = "https://api.github.com";

        public GitHubService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        }

        public async Task<GitHubUserInfo> RetrieveLoggedUserInformation(string username)
        {
            /*var httpResponse =
                await _httpClient.GetAsync($"{Url}/")*/
            return new GitHubUserInfo();
        }
    }
}
