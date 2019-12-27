using Deskberry.SQLite.Data;
using Microsoft.EntityFrameworkCore;

namespace Deskberry.SQLite.Tests.Resources.Databases
{
    public class TestDeskberryContext : DeskberryContext
    {
        public TestDeskberryContext(DbContextOptions<DeskberryContext> options, bool isProductionDatabase = true) : base(options)
            => IsProductionDatabase = isProductionDatabase;

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}