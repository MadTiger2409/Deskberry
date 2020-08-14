using Deskberry.Common.Models.Base;
using System;

namespace Deskberry.Common.Models
{
    public class HomePage : ModelBase
    {
        public HomePage() : base()
        {
        }

        public HomePage(string uri) : this() => Uri = uri;

        public HomePage(Uri uri) : this(uri.AbsoluteUri)
        { }

        public Account Account { get; set; }
        public int? AccountId { get; set; }
        public string Uri { get; protected set; }

        public void Update(string uri) => Uri = uri;

        public void Update(Uri uri) => Update(uri.AbsoluteUri);
    }
}