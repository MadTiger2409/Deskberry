using Deskberry.SQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Data
{
    public class DeskberryContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DeskberryContext(DbContextOptions<DeskberryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=deskberry.db");
        }
    }
}
