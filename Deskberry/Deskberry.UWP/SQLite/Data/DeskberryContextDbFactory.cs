using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Data
{
    class DeskberryContextDbFactory : IDesignTimeDbContextFactory<DeskberryContext>
    {
        public DeskberryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeskberryContext>();
            optionsBuilder.UseSqlite(@"Data Source=deskberry.db");

            return new DeskberryContext(optionsBuilder.Options);
        }
    }
}
