using ConsoleBoilerplate.Services.Interfaces;

namespace ConsoleBoilerplate.Services
{
    public class BusinessService : IBusinessService
    {
        private IGatewayService _gatewayService { get; set; }

        public BusinessService(IGatewayService gatewayService)
        {
            _gatewayService = gatewayService;
        }

        public async Task ProcessAsync()
        {
            await _gatewayService.GetSingleAsync();
        }
    }
}
