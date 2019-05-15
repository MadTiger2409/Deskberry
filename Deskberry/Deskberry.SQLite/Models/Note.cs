using Deskberry.SQLite.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Note : ModelBase
    {
        public string Title { get; protected set; }
        public string Content { get; protected set; }

        public int AccountId { get; protected set; }
        public Account Account { get; set; }

        public Note() : base() { }

        public Note(string title, string content) : base()
        {
            Title = title;
            Content = content;
        }

        public void Update(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
