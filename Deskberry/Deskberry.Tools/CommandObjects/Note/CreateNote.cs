using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Deskberry.Tools.CommandObjects.Note
{
    public class CreateNote : INotifyPropertyChanged
    {
        private string _title;
        private string _description;

        public event PropertyChangedEventHandler PropertyChanged;

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
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description)
                    return;

                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
    }
}
