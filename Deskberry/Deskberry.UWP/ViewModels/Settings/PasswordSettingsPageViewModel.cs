using Deskberry.Tools.CommandObjects.Password;
using Deskberry.Tools.Services.Interfaces;
using System.ComponentModel;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class PasswordSettingsPageViewModel : INotifyPropertyChanged
    {
        private IAccountService _accountService;

        public PasswordSettingsPageViewModel()
        {
        }

        public PasswordSettingsPageViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            PasswordForm = new UpdatePassword();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UpdatePassword PasswordForm { get; set; }
    }
}