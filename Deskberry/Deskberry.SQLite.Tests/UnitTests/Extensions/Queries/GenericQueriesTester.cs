using Deskberry.SQLite.Data.Extensions.Queries;
using Deskberry.Common.Models;
using Deskberry.SQLite.Tests.Resources.Databases;
using Deskberry.SQLite.Tests.Resources.UnitTests.AccountQueries;
using System.Linq;
using Xunit;

namespace Deskberry.SQLite.Tests.UnitTests.Extensions.Queries
{
    [Collection("Generic Queries Tests")]
    public class GenericQueriesTester : SQLiteDatabaseFixture
    {
        [Fact]
        public void GetById_RecordDoesntExist_NotFound()
        {
            // Arrange
            Account account;

            // Act
            account = DbContext.Accounts.GetById(10).SingleOrDefault();

            // Assert
            Assert.Null(account);
        }

        [Theory]
        [AccountGetByIdQueryData]
        public void GetById_RecordExists_Foud(string login, byte[] passwordHash, byte[] passwordSalt)
        {
            // Arrange
            Account account;
            int count;

            PrepareDbContextWithOneAvatarAndOneUser(login, passwordHash, passwordSalt, out Account expectedAccount);

            // Act
            account = DbContext.Accounts.GetById(expectedAccount.Id).SingleOrDefault();
            count = DbContext.Accounts.Count();

            // Assert
            Assert.Equal(expectedAccount.Id, account.Id);
            Assert.Equal(expectedAccount, account);
        }

        private void PrepareDbContextWithOneAvatarAndOneUser(string login, byte[] passwordHash, byte[] passwordSalt, out Account account)
        {
            var avatar = new Avatar(new byte[] { 1, 57, 137, 75 });
            account = new Account(login, passwordHash, passwordSalt, avatar);

            DbContext.Avatars.Add(avatar);
            DbContext.Accounts.Add(account);
            DbContext.SaveChanges();
        }
    }
}