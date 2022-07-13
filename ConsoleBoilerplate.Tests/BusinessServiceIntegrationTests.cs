using ConsoleBoilerplate.Services;
using ConsoleBoilerplate.Services.Interfaces;
using ConsoleBoilerplate.Tests.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Configuration;
using System.Net;

namespace ConsoleBoilerplate.Tests
{
    [TestClass]
    public class BusinessServiceIntegrationTests
    {
        [TestMethod]
        public async Task FirstIntegrationTest()
        {
            // Arrange
            var gatewayServiceLogger = Substitute.For<ILogger<IGatewayService>>();
            var businessServiceLogger = Substitute.For<ILogger<IBusinessService>>();
            var businessService = CreateBusinessService(string.Empty, gatewayServiceLogger, businessServiceLogger);

            // Act
            await businessService.ProcessAllAsync();

            // Assert
            businessServiceLogger.Received().LogInformation("ProcessAllAsync successful.");
        }

        private IBusinessService CreateBusinessService(string mockApiResponse, 
            ILogger<IGatewayService> gatewayServiceLogger,
            ILogger<IBusinessService> businessServiceLogger)
        {
            var mockConfig = Substitute.For<IConfiguration>();
            mockConfig["MockApiSingleUrl"].Returns("https://anyurl.com");
            var mockHttpClientFactory = HttpTestHelper.HttpClientFactory(mockApiResponse);
            var gatewayService = new GatewayService(mockConfig, mockHttpClientFactory, gatewayServiceLogger);
            return new BusinessService(gatewayService, businessServiceLogger);
        }
    }
}