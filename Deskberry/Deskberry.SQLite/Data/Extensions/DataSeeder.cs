using Deskberry.SQLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deskberry.SQLite.Data.Extensions
{
    public static class DataSeeder
    {
        public static void Initialize(DeskberryContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Avatars.Any())
            {
                context.Avatars.Add(new Avatar());
                context.SaveChanges();
            }

            //if (!context.Accounts.Any())
            //{
            //    context.Accounts.Add(new Account("Admin", null, null, 1));
            //    context.SaveChanges();
            //}
        }
    }
}
