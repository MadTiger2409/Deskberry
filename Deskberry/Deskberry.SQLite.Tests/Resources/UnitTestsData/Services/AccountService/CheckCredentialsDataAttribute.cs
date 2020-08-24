using Deskberry.Common.Models;
using Deskberry.Security;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Services.AccountService
{
    public class CheckCredentialsDataAttribute : DataAttribute
    {
        private PasswordManager manager = new PasswordManager();

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            manager.CalculatePasswordHash("pass123!", out byte[] salt, out byte[] hash);

            yield return new object[]
            {
                new Account("User", hash, salt),
                "pass123!",
                true
            };

            yield return new object[]
            {
                new Account("User", hash, salt),
                "guess?1",
                false
            };

            yield return new object[]
            {
                new Account("User", hash, salt),
                null,
                false
            };
        }
    }
}