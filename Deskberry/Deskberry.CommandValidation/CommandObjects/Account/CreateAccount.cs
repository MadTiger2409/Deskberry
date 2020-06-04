using Deskberry.CommandValidation.Validators;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.ComponentModel;
using System.Text;

namespace Deskberry.CommandValidation.CommandObjects.Account
{
    public class CreateAccount : INotifyPropertyChanged
    {
        protected string _login;
        protected string _password;

        public event PropertyChangedEventHandler PropertyChanged;

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
    }
}