using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Account
{
    public class AccountUpdatePasswordDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "User125",
                "P@ssw0rd1!",
                2,
                4,
                false,
                "admin"
            };

            yield return new object[]
            {
                "Paweł",
                "!eigfhg@",
                1,
                7,
                true,
                "oknqQ1"
            };
        }
    }
}