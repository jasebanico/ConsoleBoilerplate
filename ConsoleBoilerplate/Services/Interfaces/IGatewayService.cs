using ConsoleBoilerplate.Models;

namespace ConsoleBoilerplate.Services.Interfaces
{
    public interface IGatewayService
    {
        Task<ParentItem> GetSingleAsync();
        Task<ParentItem[]> GetArrayAsync();
    }
}
