﻿using Deskberry.SQLite.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Favorite : ModelBase
    {
        public string Title { get; protected set; }
        public string Uri { get; protected set; }

        public int AccountId { get; protected set; }
        public Account Account { get; set; }
    }
}
