using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.SQLite.Models;
using Deskberry.SQLite.Tests.Resources.Databases;
using Deskberry.SQLite.Tests.Resources.UnitTests.AccountQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Deskberry.SQLite.Tests.UnitTests.Extensions.Queries
{
    [Collection("Account Queries Tests")]
    public class AccountQueriesTester : IClassFixture<InMemoryDatabaseFixture>
    {
        InMemoryDatabaseFixture databaseFixture;

        public AccountQueriesTester(InMemoryDatabaseFixture _databaseFixture)
        {
            databaseFixture = _databaseFixture;
        }

        [Theory]
        [AccountGetByIdQueryData]
        public void GetById_RecordExists_Foud(string login, byte[] passwordHash, byte[] passwordSalt)
        {
            // Arrange
            Account account;
            int count;

            databaseFixture.Context.Accounts.Add(new Account(login, passwordHash, passwordSalt));
            databaseFixture.Context.SaveChanges();

            // Act
            account = databaseFixture.Context.Accounts.GetById(1).SingleOrDefault();
            count = databaseFixture.Context.Accounts.Count();

            // Assert
            Assert.Equal(1, account.Id);
        }

        [Fact]
        public void GetById_RecordDoesntExist_NotFound()
        {

        }
    }
}
