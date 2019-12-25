using System.ComponentModel;

namespace Deskberry.Tools.CommandObjects.Note
{
    public class UpdateNote : INotifyPropertyChanged
    {
        protected string _content;
        protected int _id;
        protected string _title;

        public UpdateNote()
        {
        }

        public UpdateNote(SQLite.Models.Note note)
        {
            Id = note.Id;
            Title = note.Title;
            Content = note.Content;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Content
        {
            get { return _content; }
            set
            {
                if (value == _content)
                    return;

                _content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (value == _id)
                    return;

                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title)
                    return;

                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }
    }
}