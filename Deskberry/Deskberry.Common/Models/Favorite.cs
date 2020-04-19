using Deskberry.Common.Models.Base;

namespace Deskberry.Common.Models
{
    public class Favorite : ModelBase
    {
        public Favorite() : base()
        {
        }

        public Favorite(string title, string uri) : base()
        {
            Title = title;
            Uri = uri;
        }

        public Account Account { get; set; }
        public int AccountId { get; protected set; }
        public string Title { get; protected set; }
        public string Uri { get; protected set; }

        public void Update(string title, string uri)
        {
            Title = title;
            Uri = uri;
        }
    }
}