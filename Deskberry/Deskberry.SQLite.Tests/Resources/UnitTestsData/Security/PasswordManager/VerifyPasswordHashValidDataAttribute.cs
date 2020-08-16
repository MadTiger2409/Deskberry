using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Security.PasswordManager
{
    public class VerifyPasswordHashValidDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var passwords = new string[] { "Admin", "hhu@#.1445" };
            HMACSHA512 hmac512;

            for (int i = 0; i < passwords.Length; i++)
            {
                hmac512 = new HMACSHA512();

                yield return new object[]
                {
                    passwords[i],
                    hmac512.ComputeHash(Encoding.UTF8.GetBytes(passwords[i])),
                    hmac512.Key
                };
            }
        }
    }
}