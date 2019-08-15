using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Tests.Resources.UnitTests.PasswordManager;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Deskberry.SQLite.Tests.UnitTests.Extensions.Security
{
    [Collection("Password Manager Tests")]
    public class PasswordManagerTester
    {
        [Theory]
        [CalculateHashData]
        public void CalculateHash_CorrectDataForFirstTime_Calculated(string password)
        {
            // Assert
            var passwordManager = new PasswordManager();
            byte[] passwordHash;
            byte[] passwordSalt;

            // Act
            passwordManager.CalculatePasswordHash(password, out passwordSalt, out passwordHash);

            // Assert
            Assert.NotEqual(default(byte[]), passwordHash);
            Assert.NotEqual(default(byte[]), passwordSalt);
        }
    }
}
