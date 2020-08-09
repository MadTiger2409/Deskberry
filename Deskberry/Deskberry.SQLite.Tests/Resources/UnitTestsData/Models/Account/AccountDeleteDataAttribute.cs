using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Account
{
    public sealed class AccountDeleteDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new Common.Models.Account(true)
            };

            yield return new object[]
            {
                new Common.Models.Account(false)
            };
        }
    }
}