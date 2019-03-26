﻿using Deskberry.SQLite.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Avatar : ModelBase
    {
        public byte[] Content { get; protected set; }
        public List<Account> Accounts { get; set; }

        public Avatar() : base() { }

        public Avatar(byte[] content) : base()
        {
            Content = content;
        }

        public Avatar(byte[] content, int id) : base()
        {
            Content = content;
            Id = id;
        }
    }
}
