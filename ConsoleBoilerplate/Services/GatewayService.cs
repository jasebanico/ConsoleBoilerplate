using ConsoleBoilerplate.Models;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;

namespace ConsoleBoilerplate.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public GatewayService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ParentItem> GetSingleAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiSingleUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ParentItem>(responseContent);
            }

            return null;
        }

        public async Task<ParentItem[]> GetArrayAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiArrayUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ParentItem[]>(responseContent);
            }

            return null;
        }
    }
}
