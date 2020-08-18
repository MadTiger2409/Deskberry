using Deskberry.CommandValidation.CommandObjects.Account;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Services.AccountService
{
    public class AddSpecificAccountDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = "Admin",
                    Password = "Admin"
                },
                "Admin"
            };

            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = "P@weł",
                    Password = "12345"
                },
                "P@weł"
            };
        }
    }
}