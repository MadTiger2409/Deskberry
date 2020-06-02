using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Deskberry.CommandValidation.CommandObjects.Account
{
    public class CreateAccount : INotifyPropertyChanged
    {
        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login)
                    return;

                _login = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Login)));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password)
                    return;

                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}