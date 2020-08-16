using Deskberry.Security;
using Deskberry.Tests.Resources.UnitTestsData.Security.AccountPasswordData;
using Xunit;

namespace Deskberry.Tests.UnitTests.Security
{
    [Collection("Account password's data tester")]
    public class AccountPasswordDataTester
    {
        [Theory]
        [AccountPasswordDataConstructorData]
        public void AccountPasswordData_Create(byte[] hash, byte[] salt)
        {
            // Arrange
            AccountPasswordData passwordData;

            // Act
            passwordData = new AccountPasswordData(hash, salt);

            // Assert
            Assert.Equal(hash, passwordData.PasswordHash);
            Assert.Equal(salt, passwordData.Salt);
        }
    }
}