using Deskberry.Common.Models;
using Deskberry.Tests.Resources.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Homepage tests")]
    public class HomePageTester
    {
        [Fact]
        public void HomePage_Create_DefaultConstructor()
        {
            // Arrange
            HomePage homePage;
            var startDate = DateTime.UtcNow;

            // Act
            homePage = new HomePage();

            // Assert
            Assert.True(ModelTestHelpers.CheckTime(homePage, startDate));
        }
    }
}