﻿using Deskberry.SQLite.Extensions;
using Deskberry.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Deskberry.SQLite.Data
{
    public class DeskberryContext : DbContext
    {
        public bool IsProductionDatabase { get; protected set; }

        public DeskberryContext(DbContextOptions<DeskberryContext> options) : base(options) => IsProductionDatabase = true;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<HomePage> HomePages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avatar>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Account>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Account>()
                .HasOne(x => x.Avatar)
                .WithMany(y => y.Accounts)
                .HasForeignKey(x => x.AvatarId);
            modelBuilder.Entity<Account>()
                .HasOne(x => x.HomePage)
                .WithOne(y => y.Account)
                .HasForeignKey<HomePage>(y => y.AccountId);

            modelBuilder.Entity<Favorite>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Favorite>()
                .HasOne(x => x.Account)
                .WithMany(y => y.Favorites)
                .HasForeignKey(x => x.AccountId);

            modelBuilder.Entity<Note>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Note>()
                .HasOne(x => x.Account)
                .WithMany(y => y.Notes)
                .HasForeignKey(x => x.AccountId);

            if (IsProductionDatabase)
            {
                modelBuilder.Entity<Avatar>()
                .HasData(new
                {
                    Id = 1,
                    Content = AvatarRoot.ToByteArray(AvatarRoot.DogImageBase64),
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = 2,
                    Content = AvatarRoot.ToByteArray(AvatarRoot.BirdImageBase64),
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = 3,
                    Content = AvatarRoot.ToByteArray(AvatarRoot.CatsImageBase64),
                    CreatedAt = DateTime.UtcNow
                },
                new
                {
                    Id = 4,
                    Content = AvatarRoot.ToByteArray(AvatarRoot.WolfImageBase64),
                    CreatedAt = DateTime.UtcNow
                });

                modelBuilder.Entity<Account>()
                .HasData(new Account("Admin", "admin", 1, 1));
            }
        }
    }
}