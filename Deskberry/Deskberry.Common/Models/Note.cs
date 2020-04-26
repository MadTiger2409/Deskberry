using Deskberry.Common.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Deskberry.Common.Models
{
    public class Note : ModelBase, INotifyPropertyChanged
    {
        private string _title;
        private string _content;

        public string Title
        {
            get => _title;
            protected set
            {
                if (value == _title)
                    return;

                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string Content
        {
            get => _content;
            protected set
            {
                if (value == _content)
                    return;

                _content = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Content)));
            }
        }

        public int AccountId { get; protected set; }
        public Account Account { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Note() : base()
        {
        }

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