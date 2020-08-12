using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Avatar
{
    public class AvatarContentConstructorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                new byte[] {1, 250, 5, 0, 44, 83, 168, 9, 2, 85, 108, 99, 12, 35, 233, 201}
            };
        }
    }
}