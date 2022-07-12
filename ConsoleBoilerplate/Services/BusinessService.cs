using ConsoleBoilerplate.Models;
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

        public async Task ProcessAllAsync()
        {
            var parentItem = await _gatewayService.GetSingleAsync();
            var parentItems = await _gatewayService.GetArrayAsync();
        }

        public async Task ProcessAsync(ParentItem parentItem)
        {
            parentItem.IsProcessed = true;
            foreach (var childItem in parentItem.ChildItems)
            {
                childItem.IsProcessed = true;
            }
        }

        public async Task ProcessAsync(ParentItem[] parentItems)
        {
            foreach (var parentItem in parentItems)
            {
                await ProcessAsync(parentItem);
            }
        }
    }
}
