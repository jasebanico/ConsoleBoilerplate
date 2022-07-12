using ConsoleBoilerplate.Models;

namespace ConsoleBoilerplate.Services.Interfaces
{
    internal interface IBusinessService
    {
        Task ProcessAllAsync();
        Task ProcessAsync(ParentItem parentItem);
        Task ProcessAsync(ParentItem[] parentItem);
    }
}
