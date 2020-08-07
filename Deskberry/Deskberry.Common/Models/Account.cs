using Deskberry.Common.Models.Base;
using Deskberry.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.Common.Models
{
    public class Account : ModelBase
    {
        public string Login { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }
        public bool IsActive { get; protected set; }

        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public HomePage HomePage { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Note> Notes { get; set; }

        /// <summary>
        /// Default constructor. Used mostly by Entity Framework Core.
        /// </summary>
        public Account() : base()
        {
        }

        public Account(bool isActive = true) : this() => IsActive = isActive;

        /// <summary>
        /// Constructor used to popule database with the account
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="id"></param>
        /// <param name="avatarId"></param>
        public Account(string login, string password, int id, int avatarId, bool isActive = true) : this(isActive)
        {
            var manager = new PasswordManager();
            var passData = manager.CalculatePasswordHash(password);

            Login = login;
            PasswordHash = passData.PasswordHash;
            Salt = passData.Salt;
            Id = id;
            AvatarId = avatarId;
        }

        public Account(string login, byte[] passwordHash, byte[] salt, bool isActive = true) : this(isActive)
        {
            Login = login;
            PasswordHash = passwordHash;
            Salt = salt;
        }

        public Account(string login, byte[] passwordHash, byte[] salt, Avatar avatar, bool isActive = true) : this(login, passwordHash, salt, isActive)
        {
            Avatar = avatar;
            AvatarId = avatar.Id;
        }

        public void UpdatePassword(string newPassword)
        {
            var manager = new PasswordManager();
            byte[] passHash;
            manager.CalculatePasswordHash(newPassword, Salt, out passHash);

            PasswordHash = passHash;
        }

        public void Delete() => IsActive = false;
    }
}