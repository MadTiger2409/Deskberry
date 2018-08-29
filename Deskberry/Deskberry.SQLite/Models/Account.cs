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

        public int AvatarId { get; protected set; }
        public Avatar Avatar { get; set; }
        public List<Favorite> Favorites { get; set; }
        public List<Note> Notes { get; set; }
    }
}
