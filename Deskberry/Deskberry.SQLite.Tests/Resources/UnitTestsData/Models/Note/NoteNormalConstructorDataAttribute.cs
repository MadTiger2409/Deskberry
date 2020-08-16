using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Note
{
    public class NoteNormalConstructorDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Shopping list",
                "Apple, lemon, milk, chocolate"
            };

            yield return new object[]
            {
                "My own list",
                null
            };

            yield return new object[]
            {
                null,
                "Do some programming"
            };
        }
    }
}