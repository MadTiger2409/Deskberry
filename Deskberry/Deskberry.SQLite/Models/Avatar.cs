using Deskberry.SQLite.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Avatar : ModelBase
    {
        public byte[] Content { get; protected set; }
        public List<Account> Accounts { get; set; }
    }
}
