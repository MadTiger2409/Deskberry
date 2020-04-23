using Deskberry.Security;
using Deskberry.CommandValidation.Validators;
using FluentValidation;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Deskberry.Tools.CommandObjects.Password
{
    public class UpdatePassword : INotifyPropertyChanged
    {
        private readonly PasswordManager _passwordManager;
        private readonly UpdatePasswordValidator _validator;
        private bool _isNewPasswordErrorVisible;
        private bool _isRepeatedNewPasswordVisible;
        private string _newPassword;
        private string _password;
        private string _repeatedNewPassword;

        public UpdatePassword()
        {
            IsNewPasswordErrorVisible = false;
            IsRepeatedNewPasswordVisible = false;
            _validator = new UpdatePasswordValidator();
            _passwordManager = new PasswordManager();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Action CanExecutedChanged { get; set; }

        public string CorrectPassword { get; set; }

        public bool IsNewPasswordErrorVisible
        {
            get => _isNewPasswordErrorVisible;
            set
            {
                if (value == _isNewPasswordErrorVisible)
                    return;

                _isNewPasswordErrorVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNewPasswordErrorVisible)));
            }
        }

        public bool IsRepeatedNewPasswordVisible
        {
            get => _isRepeatedNewPasswordVisible;
            set
            {
                if (value == _isRepeatedNewPasswordVisible)
                    return;

                _isRepeatedNewPasswordVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRepeatedNewPasswordVisible)));
            }
        }

        public string NewPassword
        {
            get => _newPassword;
            set
            {
                if (value == _newPassword)
                    return;

                _newPassword = value;

                IsNewPasswordErrorVisible = !_validator.Validate(this, ruleSet: "NewPassword").IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NewPassword)));
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

                ArePasswordsEqual = _passwordManager.VerifyPasswordHash(value, PasswordHash, PasswordSalt);
                _validator.Validate(this, ruleSet: "Password");

                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        public byte[] PasswordHash { private get; set; }
        public byte[] PasswordSalt { private get; set; }
        public bool ArePasswordsEqual { get; set; }

        public string RepeatedNewPassword
        {
            get => _repeatedNewPassword;
            set
            {
                if (value == _repeatedNewPassword)
                    return;

                _repeatedNewPassword = value;

                IsRepeatedNewPasswordVisible = !_validator.Validate(this, ruleSet: "RepeatedNewPassword").IsValid;
                CanExecutedChanged.Invoke();

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RepeatedNewPassword)));
            }
        }

        public async Task ClearAsync()
        {
            await Task.FromResult(Password = string.Empty);
            NewPassword = null;
            RepeatedNewPassword = null;
            IsRepeatedNewPasswordVisible = false;
            IsNewPasswordErrorVisible = false;
        }

        public bool IsValid() => _validator.Validate(this, ruleSet: "Full").IsValid;
    }
}