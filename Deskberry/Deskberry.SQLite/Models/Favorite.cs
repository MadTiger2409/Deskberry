using Deskberry.SQLite.Models.Base;
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

        public Favorite() : base() { }

        public Favorite(string title, string uri) : base()
        {
            Title = title;
            Uri = uri;
        }

        public void Update(string title, string uri)
        {
            Title = title;
            Uri = uri;
        }
    }
}
