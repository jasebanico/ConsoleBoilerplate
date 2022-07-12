using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

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

        public async Task GetSingleAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiSingleUrl"]);
        }

        public async Task GetArrayAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiArrayUrl"]);
        }
    }
}
