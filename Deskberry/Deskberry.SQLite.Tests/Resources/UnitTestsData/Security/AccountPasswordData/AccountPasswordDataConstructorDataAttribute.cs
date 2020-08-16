using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Security.AccountPasswordData
{
    public class AccountPasswordDataConstructorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new byte[] {1, 87, 78, 10, 254, 68, 213, 0, 22},
                new byte[] {1, 87, 78, 10, 213, 0, 22, 254, 68, 96, 185, 102, 198, 201 },
            };
        }
    }
}