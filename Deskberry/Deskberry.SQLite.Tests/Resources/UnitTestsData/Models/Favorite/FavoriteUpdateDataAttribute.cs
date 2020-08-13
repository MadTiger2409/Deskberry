using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Favorite
{
    public class FavoriteUpdateDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Google",
                "Bing",
                "https://www.google.com",
                "https://www.bing.com"
            };
        }
    }
}