using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Deskberry.SQLite.Data.Extensions
{
    public class DeskberryContextFactory : IDesignTimeDbContextFactory<DeskberryContext>
    {
        public DeskberryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeskberryContext>();
            optionsBuilder.UseSqlite(@"Data Source=deskberry.db");

            return new DeskberryContext(optionsBuilder.Options);
        }
    }
}