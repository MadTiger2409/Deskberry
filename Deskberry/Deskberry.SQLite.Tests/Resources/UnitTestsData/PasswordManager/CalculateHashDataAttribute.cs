using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.PasswordManager
{
    public class CalculateHashDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Admin"
            };

            yield return new object[]
            {
                "hhu@#.1445"
            };
        }
    }
}