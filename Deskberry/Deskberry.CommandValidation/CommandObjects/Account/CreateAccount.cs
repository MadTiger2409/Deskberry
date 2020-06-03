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
        protected bool _isLoginErrorVisible;
        protected bool _isPasswordErrorVisible;
        protected string _login;
        protected string _password;

        private readonly CreateAccountValidator _validator;

        public CreateAccount()
        {
            IsLoginErrorVisible = false;
            IsPasswordErrorVisible = false;
            _validator = new CreateAccountValidator();
        }

        public CreateAccount(Action canExecuteChanged) : base() => CanExecuteChanged = canExecuteChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CanExecuteChanged { get; set; }

        public bool IsLoginErrorVisible
        {
            get { return _isLoginErrorVisible; }
            set
            {
                if (value == _isLoginErrorVisible)
                    return;

                _isLoginErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoginErrorVisible)));
            }
        }

        public bool IsPasswordErrorVisible
        {
            get { return _isPasswordErrorVisible; }
            set
            {
                if (value == _isPasswordErrorVisible)
                    return;

                _isPasswordErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPasswordErrorVisible)));
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                if (value == _login)
                    return;

                _login = value;

                IsLoginErrorVisible = !_validator.Validate(this, ruleSet: "Login").IsValid;
                CanExecuteChanged.Invoke();

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

                IsPasswordErrorVisible = !_validator.Validate(this, ruleSet: "Password").IsValid;
                CanExecuteChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
    }
}