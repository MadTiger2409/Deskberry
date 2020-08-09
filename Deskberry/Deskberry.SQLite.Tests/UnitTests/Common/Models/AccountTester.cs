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
            Assert.True(CheckTime(account, startDate));
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
            Assert.True(CheckTime(account, startDate));
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
            Assert.True(CheckTime(account, startDate));
            Assert.True(account.Salt != null && account.Salt.Length > 0);
            Assert.True(account.PasswordHash != null && account.PasswordHash.Length > 0);
        }

        [Theory]
        [AccountNormalConstructorData]
        public void Account_Create_NormalConstructor(string login, bool isActive)
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;
            var hash = new byte[] { 1, 15, 55, 230, 17, 215, 5, 20, 0, 15, 68, 89 };
            var salt = new byte[] { 17, 215, 5, 20, 80, 215, 5, 20, 0, 15, 68, 145, 138, 9 };

            // Act
            account = new Account(login, hash, salt, isActive);

            // Assert
            Assert.Equal(login, account.Login);
            Assert.Equal(isActive, account.IsActive);
            Assert.True(CheckTime(account, startDate));
            Assert.True(account.Salt == salt);
            Assert.True(account.PasswordHash == hash);
        }

        [Fact]
        public void Account_Create_AvatarConstructor()
        { }

        [Fact]
        public void Account_UpdatePassword()
        { }

        [Theory]
        [AccountDeleteData]
        public void Account_Delete(Account account)
        {
            // Act
            account.Delete();

            Assert.False(account.IsActive);
        }

        private bool CheckTime(Account account, DateTime testStartTime) => (account.CreatedAt != default) && (account.CreatedAt.Ticks > testStartTime.Ticks);
    }
}