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
    public class AccountQueriesTester : SQLiteDatabaseFixture
    {
        private void PrepareDbContextWithOneAvatarAndOneUser(string login, byte[] passwordHash, byte[] passwordSalt)
        {
            var avatar = new Avatar(new byte[] { 1, 57, 137, 75 });

            DbContext.Avatars.Add(avatar);
            DbContext.Accounts.Add(new Account(login, passwordHash, passwordSalt, avatar));
            DbContext.SaveChanges();
        }

        [Theory]
        [AccountGetByIdQueryData]
        public void GetById_RecordExists_Foud(string login, byte[] passwordHash, byte[] passwordSalt)
        {
            // Arrange
            Account account;
            int count;

            PrepareDbContextWithOneAvatarAndOneUser(login, passwordHash, passwordSalt);

            // Act
            account = DbContext.Accounts.GetById(1).SingleOrDefault();
            count = DbContext.Accounts.Count();

            // Assert
            Assert.Equal(1, count);
            Assert.Equal(1, account.Id);
        }

        [Fact]
        public void GetById_RecordDoesntExist_NotFound()
        {

        }
    }
}
