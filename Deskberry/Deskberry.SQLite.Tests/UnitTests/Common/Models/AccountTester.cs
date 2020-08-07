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
        public void Account_CreateDefault_Success()
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
    }
}