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
        public DbSet<Avatar> Avatars { get; set; }

        public DeskberryContext(DbContextOptions<DeskberryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Account>()
                .HasOne(x => x.Avatar)
                .WithMany(y => y.Accounts)
                .HasForeignKey(x => x.AvatarId);

            modelBuilder.Entity<Avatar>()
                .HasKey(x => x.Id);
        }
    }
}
