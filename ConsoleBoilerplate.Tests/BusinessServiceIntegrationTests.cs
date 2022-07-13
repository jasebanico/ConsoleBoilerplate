using ConsoleBoilerplate.Services;
using ConsoleBoilerplate.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ConsoleBoilerplate.Tests
{
    [TestClass]
    public class BusinessServiceIntegrationTests
    {
        [TestMethod]
        public async Task FirstIntegrationTest()
        {
            // Arrange
            var businessService = CreateBusinessService();

            // Act
            await businessService.ProcessAllAsync();

            // Assert
            //parentItem.IsProcessed.Should().BeTrue();
        }

        private IBusinessService CreateBusinessService()
        {
            var gatewayService = Substitute.For<IGatewayService>();
            return new BusinessService(gatewayService);
        }
    }
}