using Deskberry.CommandValidation.CommandObjects.Account;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Services.AccountService
{
    public class AddDefaultAccountDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = string.Empty,
                    Password = string.Empty
                }
            };

            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = null,
                    Password = string.Empty
                }
            };

            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = string.Empty,
                    Password = null
                }
            };

            yield return new object[]
            {
                new CreateAccount()
                {
                    Login = null,
                    Password = null
                }
            };
        }
    }
}