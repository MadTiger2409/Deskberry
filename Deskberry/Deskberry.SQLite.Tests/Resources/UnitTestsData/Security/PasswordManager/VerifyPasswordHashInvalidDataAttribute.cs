﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Security.PasswordManager
{
    public class VerifyPasswordHashInvalidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Admin",
                new byte[] { 1, 0, 22, 14, 9, 240 },
                new byte[] { 1, 0, 22, 14, 9, 2, 78, 22, 65, 6, 86, 46, 234, 2, 8, 9, 77 },
            };

            yield return new object[]
            {
                "hhu@#.1445",
                new byte[] { 1, 0, 22, 14, 9, 2, 78, 22, 65, 6, 86, 46, 234, 2, 8, 9, 77 },
                new byte[] { 1, 0, 22, 14, 9, 240 }
            };
        }
    }
}