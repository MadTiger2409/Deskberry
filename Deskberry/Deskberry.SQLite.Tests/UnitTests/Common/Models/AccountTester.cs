using Deskberry.Common.Models;
using Deskberry.Tests.Resources.UnitTestsData.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.Tests.UnitTests.Common.Models
{
    [Collection("Account Tests")]
    public class AccountTester
    {
        [Fact]
        public void Account_Create_DefaultConstructor()
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;

            // Act
            account = new Account();

            // Assert
            Assert.NotEqual(default, account.CreatedAt);
            Assert.True(account.CreatedAt.Ticks > startDate.Ticks);
        }

        [Theory]
        [AccountIsActiveConstructorData]
        public void Account_Create_IsActiveConstructor(bool isActive)
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;

            // Act
            account = new Account(isActive);

            // Assert
            Assert.Equal(isActive, account.IsActive);
            Assert.NotEqual(default, account.CreatedAt);
            Assert.True(account.CreatedAt.Ticks > startDate.Ticks);
        }

        [Theory]
        [AccountPopulationConstructorData]
        public void Account_Create_PopulationConstructor(string login, string password, int id, int avatarId, bool isActive)
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;

            // Act
            account = new Account(login, password, id, avatarId, isActive);

            // Assert
            Assert.Equal(id, account.Id);
            Assert.Equal(login, account.Login);
            Assert.Equal(avatarId, account.AvatarId);
            Assert.Equal(isActive, account.IsActive);
            Assert.NotEqual(default, account.CreatedAt);
            Assert.True(account.CreatedAt.Ticks > startDate.Ticks);
            Assert.True(account.Salt != null && account.Salt.Length > 0);
            Assert.True(account.PasswordHash != null && account.PasswordHash.Length > 0);
        }
    }
}