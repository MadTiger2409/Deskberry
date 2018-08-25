using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Account
    {
        public int Id { get; protected set; }
        public string Login { get; protected set; }
        public byte[] PasswordHash { get; protected set; }
        public byte[] Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public int AvatarId { get; protected set; }
        public Avatar Avatar { get; set; }
    }
}
