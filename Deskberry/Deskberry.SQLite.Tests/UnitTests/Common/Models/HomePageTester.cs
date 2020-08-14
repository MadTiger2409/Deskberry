using Deskberry.Common.Models;
using Deskberry.Tests.Resources.Helpers;
using Deskberry.Tests.Resources.UnitTestsData.Models.HomePage;
using Moq;
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

        [Theory]
        [HomePageUriConstructorData]
        public void HomePage_Create_StringUriConstructor(string uri)
        {
            // Arrange
            HomePage homePage;
            var startDate = DateTime.UtcNow;

            // Act
            homePage = new HomePage(uri);

            // Assert
            Assert.Equal(uri, homePage.Uri);
            Assert.True(ModelTestHelpers.CheckTime(homePage, startDate));
        }

        [Theory]
        [HomePageUriConstructorData]
        public void HomePage_Create_ObjectUriConstructor(string uri)
        {
            // Arrange
            HomePage homePage;
            var startDate = DateTime.UtcNow;

            var uriMock = new Mock<Uri>();
            var uriObject = new Uri(uri);

            // Act
            homePage = new HomePage(uriObject);

            // Assert
            Assert.Equal(uri, homePage.Uri);
            Assert.True(ModelTestHelpers.CheckTime(homePage, startDate));
        }
    }
}