using Deskberry.Common.Models;
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
        public void Account_CreateDefault()
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

        [Fact]
        public void Account_CreateActive()
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;

            // Act
            account = new Account(true);

            // Assert
            Assert.True(account.IsActive);
            Assert.NotEqual(default, account.CreatedAt);
            Assert.True(account.CreatedAt.Ticks > startDate.Ticks);
        }

        [Fact]
        public void Account_CreateInactive()
        {
            // Arrange
            Account account;
            var startDate = DateTime.UtcNow;

            // Act
            account = new Account(false);

            // Assert
            Assert.False(account.IsActive);
            Assert.NotEqual(default, account.CreatedAt);
            Assert.True(account.CreatedAt.Ticks > startDate.Ticks);
        }
    }
}