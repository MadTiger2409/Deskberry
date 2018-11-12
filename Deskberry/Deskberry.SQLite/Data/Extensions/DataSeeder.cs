using Deskberry.SQLite.Extensions;
using Deskberry.SQLite.Extensions.Security;
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

            var avatarRoot = new AvatarRoot();
            var avatar = new Avatar(avatarRoot.ToByteArray(avatarRoot.Dog));

            if (!context.Avatars.Any())
            {
                context.Avatars.Add(avatar);
                context.Avatars.Add(new Avatar(avatarRoot.ToByteArray(avatarRoot.Cats)));
                context.Avatars.Add(new Avatar(avatarRoot.ToByteArray(avatarRoot.Bird)));
                context.Avatars.Add(new Avatar(avatarRoot.ToByteArray(avatarRoot.Wolf)));

                context.SaveChanges();
            }

            if (!context.Accounts.Any())
            {
                var password = "admin";
                byte[] passwordHash, passwordSalt;
                var passwordManager = new PasswordManager();

                passwordManager.CalculatePasswordHash(password, out passwordHash, out passwordSalt);

                context.Accounts.Add(new Account("Admin", passwordHash, passwordSalt, avatar));
                context.SaveChanges();
            }
        }
    }
}
