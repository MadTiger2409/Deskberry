using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace Deskberry.SQLite.Tests.Resources.UnitTests.NoteQueries
{
    public class NoteGetByIdQueryDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
            {
                "Test note",
                "This is test note"
            };

            yield return new object[]
            {
                "Shopping",
                "Buy some apples, meat and milk."
            };
        }
    }
}
