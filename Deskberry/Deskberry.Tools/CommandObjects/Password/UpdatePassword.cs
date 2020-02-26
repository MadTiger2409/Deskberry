using Deskberry.Tools.Validators;
using System.ComponentModel;

namespace Deskberry.Tools.CommandObjects.Password
{
    public class UpdatePassword : INotifyPropertyChanged
    {
        private readonly UpdatePasswordValidator _validator;
        private bool _isNewPasswordErrorVisible;
        private bool _isRepeatedNewPasswordVisible;
        private string _correctPassword;
        private string _newPassword;
        private string _password;
        private string _repeatedNewPassword;

        public UpdatePassword()
        {
            IsNewPasswordErrorVisible = false;
            IsRepeatedNewPasswordVisible = false;
            _validator = new UpdatePasswordValidator();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string NewPassword { get => _newPassword; set => _newPassword = value; }
        public string CorrectPassword { get => _correctPassword; set => _correctPassword = value; }
        public string Password { get => _password; set => _password = value; }
        public string RepeatedNewPassword { get => _repeatedNewPassword; set => _repeatedNewPassword = value; }
    }
}