using ConsoleBoilerplate.Models;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

namespace ConsoleBoilerplate.Services
{
    public class GatewayService : IGatewayService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<IGatewayService> _logger;

        public GatewayService(IConfiguration configuration, 
            IHttpClientFactory httpClientFactory, ILogger<IGatewayService> logger)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<ParentItem> GetSingleAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiSingleUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Get single successful.");
                return JsonSerializer.Deserialize<ParentItem>(responseContent);
            }

            _logger.LogError($"Get single failed. Status: {0}", response.StatusCode);
            return null;
        }

        public async Task<ParentItem[]> GetArrayAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("MockApi");
            var response = await httpClient.GetAsync(_configuration["MockApiArrayUrl"]);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Get array successful.");
                return JsonSerializer.Deserialize<ParentItem[]>(responseContent);
            }

            _logger.LogError($"Get single failed. Status: {0}", response.StatusCode);
            return null;
        }
    }
}
