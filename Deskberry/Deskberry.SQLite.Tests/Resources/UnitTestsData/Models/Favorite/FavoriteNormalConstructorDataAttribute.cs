using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Favorite
{
    public class FavoriteNormalConstructorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Google",
                "http://www.google.com"
            };

            yield return new object[]
            {
                "Local server",
                "http://localhost:5000"
            };
        }
    }
}