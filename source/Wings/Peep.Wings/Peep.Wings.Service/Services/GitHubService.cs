using System;
using System.Threading.Tasks;
using System.Net.Http;
using Peep.Wings.Domain.Services;

namespace Peep.Wings.Service.Services
{
    public class GitHubService : IOAuthService
    {
        private readonly HttpClient _httpClient;
        private const string Url = "";

        public GitHubService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public Task RetrieveLoggedUserInformation(string userIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
