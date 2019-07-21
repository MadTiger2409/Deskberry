using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Deskberry.Tools.CommandObjects.Note
{
    public class UpdateNote : INotifyPropertyChanged
    {
        protected int _id;
        protected string _title;
        protected string _content;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public UpdateNote() { }

        public UpdateNote(SQLite.Models.Note note)
        {
            Id = note.Id;
            Title = note.Title;
            Content = note.Content;
        }
    }
}
