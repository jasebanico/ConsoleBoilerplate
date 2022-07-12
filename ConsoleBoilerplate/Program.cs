// See https://aka.ms/new-console-template for more information
using ConsoleBoilerplate.Services;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddHttpClient<IGatewayService, GatewayService>("MockApi", client =>
{
    client.BaseAddress = new Uri(config["MockApiBaseUrl"]);
    //client.DefaultRequestHeaders.Add("X-Api-Key", "some-key-value");
});

var serviceProvider = serviceCollection.AddLogging()
    .AddSingleton<IConfiguration>(config)
    .AddSingleton<IGatewayService, GatewayService>()
    .AddSingleton<IDataService, DataService>()
    .AddSingleton<IBusinessService, BusinessService>()
    .BuildServiceProvider();

serviceProvider
    .GetService<ILoggerFactory>()
    .CreateLogger<Program>();

var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();

Console.WriteLine("ConsoleBoilerplate v1.0");

logger.LogDebug("Starting application.");

var businessService = serviceProvider.GetService<IBusinessService>();
await businessService.ProcessAllAsync();

logger.LogDebug("Finished processing.");

Console.WriteLine();