using ConsoleBoilerplate.Models;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ConsoleBoilerplate.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IGatewayService _gatewayService;
        private readonly ILogger<IBusinessService> _logger;

        public BusinessService(IGatewayService gatewayService, ILogger<IBusinessService> logger)
        {
            _gatewayService = gatewayService;
            _logger = logger;
        }

        public async Task ProcessAllAsync()
        {
            var parentItem = await _gatewayService.GetSingleAsync();
            _logger.LogInformation("ProcessAllAsync successful.");
        }
    }
}
