using Deskberry.SQLite.Models.Base;
using System;

namespace Deskberry.SQLite.Models
{
    public class HomePage : ModelBase
    {
        public HomePage()
        {
        }

        public HomePage(string uri) : base() => Uri = uri;

        public HomePage(Uri uri) : base() => Uri = uri.AbsoluteUri;

        public Account Account { get; set; }
        public int? AccountId { get; set; }
        public string Uri { get; protected set; }

        public void Update(string uri) => Uri = uri;

        public void Update(Uri uri) => Uri = uri.AbsoluteUri;
    }
}