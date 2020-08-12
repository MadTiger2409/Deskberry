using Deskberry.Common.Models;
using Deskberry.Tests.Resources.Helpers;
using Deskberry.Tests.Resources.UnitTestsData.Models.Avatar;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Avatar Tests")]
    public class AvatarTester
    {
        [Fact]
        public void Avatar_Create_DefaultConstructor()
        {
            // Arrange
            Avatar avatar;
            var startDate = DateTime.UtcNow;

            // Act
            avatar = new Avatar();

            // Assert
            Assert.True(ModelTestHelpers.CheckTime(avatar, startDate));
        }

        [Theory]
        [AvatarContentConstructorData]
        public void Avatar_Create_ContentConstructor(byte[] content)
        {
            // Arrange
            Avatar avatar;
            var startDate = DateTime.UtcNow;

            // Act
            avatar = new Avatar(content);

            // Assert
            Assert.Equal(content, avatar.Content);
            Assert.True(ModelTestHelpers.CheckTime(avatar, startDate));
        }

        [Theory]
        [AvatarPopulationConstructorData]
        public void Avatar_Create_PopulationConstructor(byte[] content, int id)
        {
            // Arrange
            Avatar avatar;
            var startDate = DateTime.UtcNow;

            // Act
            avatar = new Avatar(content, id);

            // Assert
            Assert.Equal(id, avatar.Id);
            Assert.Equal(content, avatar.Content);
            Assert.True(ModelTestHelpers.CheckTime(avatar, startDate));
        }
    }
}