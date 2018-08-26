using System;
using System.Collections.Generic;
using System.Text;

namespace Deskberry.SQLite.Models
{
    public class Favorite
    {
        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public string Uri { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public int AccountId { get; protected set; }
        public Account Account { get; set; }
    }
}
