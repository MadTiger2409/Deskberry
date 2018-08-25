﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Data
{
    public class DeskberryContextDbFactory : IDesignTimeDbContextFactory<DeskberryContext>
    {
        public DeskberryContext CreateDbContext(string[] args)
            => CreateSQLDbContext();

        public DeskberryContext CreateDbContext()
            => CreateSQLDbContext();

        private DeskberryContext CreateSQLDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeskberryContext>();
            optionsBuilder.UseSqlite(@"Data Source=deskberry.db");

            return new DeskberryContext(optionsBuilder.Options);
        }
    }
}
