using Deskberry.SQLite.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Tests.Resources.Databases
{
    public class SQLiteDatabaseFixture : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly DeskberryContext DbContext;

        protected SQLiteDatabaseFixture()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<DeskberryContext>()
                    .UseSqlite(_connection, x => x.SuppressForeignKeyEnforcement())
                    .Options;
            DbContext = new DeskberryContext(options, false);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
