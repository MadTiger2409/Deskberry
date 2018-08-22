using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Avatar
    {
        public int Id { get; protected set; }
        public byte[] Content { get; protected set; }
        public List<Account> Accounts { get; set; }
    }
}
