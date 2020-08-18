using Deskberry.CommandValidation.CommandObjects.Account;
using Deskberry.Common.Models;
using Deskberry.Services;
using Deskberry.Tests.Resources.Databases;
using Deskberry.Tests.Resources.UnitTestsData.Services.AccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Deskberry.Tests.UnitTests.Services
{
    [Collection("Account service's tests")]
    public class AccountServiceTester : SQLiteDatabaseFixture
    {
        [Fact]
        public async Task AccountService_AddAccountAsync_ArgumentNullException()
        {
            // Arrange
            CreateAccount createAccountCommand = null;
            AccountService accountService = new AccountService(DbContext);

            // Act and assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => accountService.AddAccountAsync(createAccountCommand));
        }

        [Theory]
        [AddDefaultAccountData]
        public async Task AccountService_AddAccountAsync_DefaultAccount(CreateAccount command)
        {
            // Arrange
            PrepareDbContextWithOneAvatar();
            int accountsCountBefore = DbContext.Accounts.Count();
            AccountService accountService = new AccountService(DbContext);

            // Act
            await accountService.AddAccountAsync(command);
            var accountsCountAfter = DbContext.Accounts.Count();
            var account = DbContext.Accounts.SingleOrDefault(x => x.Login == "User");

            // Assert
            Assert.NotNull(account);
            Assert.Equal(accountsCountBefore + 1, accountsCountAfter);
            Assert.Equal("User", account.Login);
        }

        [Theory]
        [AddSpecificAccountData]
        public async Task AccountService_AddAccountAsync_SpecificAccount(CreateAccount command, string expectedLogin)
        {
            // Arrange
            PrepareDbContextWithOneAvatar();
            int accountsCountBefore = DbContext.Accounts.Count();
            AccountService accountService = new AccountService(DbContext);

            // Act
            await accountService.AddAccountAsync(command);
            var accountsCountAfter = DbContext.Accounts.Count();
            var account = DbContext.Accounts.SingleOrDefault(x => x.Login == expectedLogin);

            // Assert
            Assert.NotNull(account);
            Assert.Equal(accountsCountBefore + 1, accountsCountAfter);
            Assert.Equal(expectedLogin, account.Login);
        }

        [Fact]
        public async Task AccountService_AreCredentialsValidAsync()
        {
        }

        private void PrepareDbContextWithOneAvatar()
        {
            var avatar = new Avatar(new byte[] { 1, 57, 137, 75 });
            DbContext.Avatars.Add(avatar);
            DbContext.SaveChanges();
        }
    }
}