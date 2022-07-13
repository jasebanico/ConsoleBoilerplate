using ConsoleBoilerplate.Models;

namespace ConsoleBoilerplate.Services.Interfaces
{
    public interface IBusinessHelper
    {
        void Process(ParentItem parentItem);
        void Process(ParentItem[] parentItem);
    }
}
