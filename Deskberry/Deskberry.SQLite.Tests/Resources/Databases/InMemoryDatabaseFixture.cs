using Deskberry.SQLite.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Tests.Resources.Databases
{
    public class InMemoryDatabaseFixture : IDisposable
    {
        public DeskberryContext Context { get; private set; }

        public InMemoryDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<DeskberryContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            Context = new DeskberryContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
