using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.HomePage
{
    public class HomePageUriConstructorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "https://www.google.com/"
            };
        }
    }
}