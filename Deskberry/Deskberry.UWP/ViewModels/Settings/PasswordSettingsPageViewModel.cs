using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Password;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class PasswordSettingsPageViewModel
    {
        private readonly IAccountService _accountService;
        private Account _account;

        public PasswordSettingsPageViewModel()
        {
        }

        public PasswordSettingsPageViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            PasswordForm = new UpdatePassword();

            InitializeCommands();

            PasswordForm.CanExecutedChanged = SaveCommand.RaiseCanExecuteChanged;
        }

        public async Task InitializeData()
        {
            _account = await _accountService.GetAsync(Session.Id);
            PasswordForm.PasswordSalt = _account.Salt;
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand ResetCommand { get; private set; }
        public UpdatePassword PasswordForm { get; set; }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(async () => await SavePasswordAsync(), PasswordForm.IsValid);
            ResetCommand = new RelayCommand(async () => await ResetPasswordFormAsync());
        }

        private async Task SavePasswordAsync() => await _accountService.UpdatePasswordAsync(_account, PasswordForm.NewPassword);

        private async Task ResetPasswordFormAsync() => await PasswordForm.ClearAsync();
    }
}