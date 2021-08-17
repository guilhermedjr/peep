using System;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Peep.Wings.Domain.Dtos;
using Peep.Wings.Domain.Services;

namespace Peep.Wings.Service.Services
{
    public class PeepStorkService : IPeepStorkService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public PeepStorkService(
            HttpClient httpClient,
            IConfiguration config) 
        {
            this._httpClient = httpClient;
            this._config = config;
        }

        public async Task AddUser(SyncUserDto syncUserDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(syncUserDto),
                Encoding.UTF8,
                "application/json");

            var httpResponse = await _httpClient.PostAsync(_config.GetSection("APIs")["Stork"], httpContent);
            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task UpdateUser(SyncUserDto syncUserDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(syncUserDto),
                Encoding.UTF8,
                "application/json");

            var httpResponse = await _httpClient.PutAsync(_config.GetSection("APIs")["Stork"], httpContent);
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
