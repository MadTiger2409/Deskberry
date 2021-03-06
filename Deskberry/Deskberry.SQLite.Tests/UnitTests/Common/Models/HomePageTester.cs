﻿using Deskberry.Common.Models;
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

        [Theory]
        [HomePageUpdateUriData]
        public void HomePage_UpdateUri_String(string uri, string newUri)
        {
            // Arrange
            HomePage homePage = new HomePage(uri);

            // Act
            homePage.Update(newUri);

            // Assert
            Assert.Equal(newUri, homePage.Uri);
        }

        [Theory]
        [HomePageUpdateUriData]
        public void HomePage_UpdateUri_Object(string uri, string newUri)
        {
            // Arrange
            HomePage homePage = new HomePage(uri);
            Uri newUriObject = new Uri(newUri);

            // Act
            homePage.Update(newUriObject);

            // Assert
            Assert.Equal(newUri, homePage.Uri);
        }
    }
}