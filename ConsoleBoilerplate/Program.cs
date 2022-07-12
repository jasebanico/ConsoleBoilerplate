// See https://aka.ms/new-console-template for more information
using ConsoleBoilerplate.Services;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<IGatewayService, GatewayService>()
            .AddSingleton<IDataService, DataService>()
            .AddSingleton<IBusinessService, BusinessService>()
            .BuildServiceProvider();

serviceProvider
    .GetService<ILoggerFactory>()
    .CreateLogger<Program>();

var logger = serviceProvider.GetService<ILoggerFactory>()
            .CreateLogger<Program>();
logger.LogDebug("Starting application.");

var businessService = serviceProvider.GetService<IBusinessService>();
await businessService.ProcessAsync();

Console.WriteLine("Finished processing.");

