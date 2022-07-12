namespace ConsoleBoilerplate.Services.Interfaces
{
    public interface IGatewayService
    {
        Task GetSingleAsync();
        Task GetArrayAsync();
    }
}
