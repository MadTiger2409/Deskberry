using Deskberry.CommandValidation.CommandObjects.Account;
using Deskberry.Services;
using Deskberry.Tests.Resources.Databases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Deskberry.Tests.UnitTests.Services
{
    [Collection("Account service's tests")]
    public class AccountServiceTester : SQLiteDatabaseFixture
    {
        [Fact]
        public async Task AccountService_AddAccount_ArgumentNullException()
        {
            // Arrange
            CreateAccount createAccountCommand = null;
            AccountService accountService = new AccountService(DbContext);

            // Act and assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => accountService.AddAccountAsync(createAccountCommand));
        }
    }
}