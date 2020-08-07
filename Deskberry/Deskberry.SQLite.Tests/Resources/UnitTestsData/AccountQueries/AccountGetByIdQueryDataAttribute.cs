using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.AccountQueries
{
    public class AccountGetByIdQueryDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Admin",
                new byte[] { 1, 25, 86, 44, 135, 9, 0, 24, 233 },
                new byte[] { 1, 25, 86, 44, 96, 56, 62, 167, 233 },
            };

            yield return new object[]
            {
                "Anson",
                new byte[] { 18, 25, 86, 63, 226, 93, 90, 24, 213 },
                new byte[] { 1, 25, 86, 93, 90, 24, 56, 62, 167, 233 },
            };
        }
    }
}