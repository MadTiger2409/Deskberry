using Deskberry.SQLite.Extensions;
using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Account : ModelBase
    {
        public string Login { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }

        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Note> Notes { get; set; }

        public Account() : base() { }

        /// <summary>
        /// Constructor used to popule database with the account
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <param name="avatarId"></param>
        public Account(string login, string password, int id, int avatarId) : base()
        {
            var manager = new PasswordManager();
            var passData = manager.CalculatePasswordHash(password);

            Login = login;
            PasswordHash = passData.PasswordHash;
            Salt = passData.Salt;
            Id = id;
            AvatarId = avatarId;
        }

        public Account(string login, byte[] passwordHash, byte[] salt) : base()
        {
            Login = login;
            PasswordHash = passwordHash;
            Salt = salt;
        }

        public Account(string login, byte[] passwordHash, byte[] salt, Avatar avatar) : this(login, passwordHash, salt)
        {
            Avatar = avatar;
            AvatarId = avatar.Id;
        }
    }
}
