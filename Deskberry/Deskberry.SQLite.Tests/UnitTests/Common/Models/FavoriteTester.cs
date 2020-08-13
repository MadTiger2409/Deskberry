using Deskberry.Common.Models;
using Deskberry.Tests.Resources.Helpers;
using Deskberry.Tests.Resources.UnitTestsData.Models.Favorite;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Favorite Tests")]
    public class FavoriteTester
    {
        [Fact]
        public void Favorite_Create_DefaultConstructor()
        {
            // Arrange
            Favorite favorite;
            var startDate = DateTime.UtcNow;

            // Act
            favorite = new Favorite();

            // Assert
            Assert.True(ModelTestHelpers.CheckTime(favorite, startDate));
        }

        [Theory]
        [FavoriteNormalConstructorData]
        public void Favorite_Create_NormalConstructor(string title, string uri)
        {
            // Arrange
            Favorite favorite;
            var startDate = DateTime.UtcNow;

            // Act
            favorite = new Favorite(title, uri);

            // Assert
            Assert.Equal(title, favorite.Title);
            Assert.Equal(uri, favorite.Uri);
            Assert.True(ModelTestHelpers.CheckTime(favorite, startDate));
        }

        [Theory]
        [FavoriteUpdateData]
        public void Favorite_UpdateData(string title, string newTitle, string uri, string newUri)
        {
            // Arrange
            Favorite favorite = new Favorite(title, uri);

            // Act
            favorite.Update(newTitle, newUri);

            // Assert
            Assert.Equal(newUri, favorite.Uri);
            Assert.NotEqual(uri, favorite.Uri);
            Assert.Equal(newTitle, favorite.Title);
            Assert.NotEqual(title, favorite.Title);
        }
    }
}