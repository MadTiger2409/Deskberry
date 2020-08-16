using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.Tests.Resources.UnitTestsData.Models.Note
{
    public class NoteUpdateDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Simple note",
                "This is simple note",
                "Updated note",
                "This is updated note"
            };

            yield return new object[]
           {
                "Simple note",
                null,
                null,
                "This is updated note"
           };
        }
    }
}