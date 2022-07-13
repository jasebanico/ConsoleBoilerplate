using ConsoleBoilerplate.Models;
using ConsoleBoilerplate.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleBoilerplate.Tests
{
    [TestClass]
    public class BusinessHelperUnitTest
    {
        [TestMethod]
        public void FirstUnitTest()
        {
            // Arrange
            var parentItem = new ParentItem();
            parentItem.IsProcessed.Should().BeFalse();

            // Act
            BusinessHelper.Process(parentItem);

            // Assert
            parentItem.IsProcessed.Should().BeTrue();
        }
    }
}