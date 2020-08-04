using Deskberry.SQLite.Extensions;
using Deskberry.Security;
using Deskberry.SQLite.Tests.Resources.UnitTests.PasswordManager;
using Moq;
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
            // Arange
            var passwordManager = new PasswordManager();

            // Act
            passwordManager.CalculatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash);

            // Assert
            Assert.NotEqual(default(byte[]), passwordHash);
            Assert.NotEqual(default(byte[]), passwordSalt);
        }

        [Theory]
        [CalculateHashAgainData]
        public void CalculateHash_CorrectDataAfterFirstTime_Calculated(string password, byte[] passwordSalt)
        {
            // Arrange
            var passwordManager = new PasswordManager();

            // Act
            passwordManager.CalculatePasswordHash(password, passwordSalt, out byte[] firstPasswordHash);
            passwordManager.CalculatePasswordHash(password, passwordSalt, out byte[] secondPasswordHash);

            // Assert
            Assert.NotEqual(default(byte[]), firstPasswordHash);
            Assert.Equal(firstPasswordHash, secondPasswordHash);
        }

        [Theory]
        [CalculateHashData]
        public void CalculateHash_CorrectData_Calculated(string password)
        {
            // Arrange
            var passwordManager = new PasswordManager();
            AccountPasswordData accountPasswordData;

            // Act
            accountPasswordData = passwordManager.CalculatePasswordHash(password);

            // Assert
            Assert.NotEqual(default(byte[]), accountPasswordData.Salt);
            Assert.NotEqual(default(byte[]), accountPasswordData.PasswordHash);
        }

        [Theory]
        [VerifyPasswordHashValidData]
        public void VerifyPasswordHash_CorrectData_Verified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Arrange
            bool? verified;
            var passwordManager = new PasswordManager();

            // Act
            verified = passwordManager.VerifyPasswordHash(password, passwordHash, passwordSalt);

            // Assert
            Assert.NotNull(verified);
            Assert.True(verified);
        }

        [Theory]
        [VerifyPasswordHashInvalidData]
        public void VerifyPasswordHash_IncorrectData_Unverified(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // Arrange
            bool? verified;
            var passwordManager = new PasswordManager();

            // Act
            verified = passwordManager.VerifyPasswordHash(password, passwordHash, passwordSalt);

            // Assert
            Assert.NotNull(verified);
            Assert.False(verified);
        }
    }
}