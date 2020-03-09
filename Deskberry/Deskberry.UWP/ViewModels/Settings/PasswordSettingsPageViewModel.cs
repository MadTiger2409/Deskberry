using Deskberry.SQLite.Extensions.Security;
using Deskberry.SQLite.Models;
using Deskberry.Tools.CommandObjects.Password;
using Deskberry.Tools.Extensions;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Helpers;
using System.ComponentModel;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

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

        public async Task InitializeDataAsync()
        {
            _account = await _accountService.GetAsync(Session.Id);
            PasswordForm.CorrectPassword = _account.PasswordHash.ToString();
            PasswordForm.PasswordSalt = _account.Salt;
            PasswordForm.PasswordHash = _account.PasswordHash;
        }

        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand ResetCommand { get; private set; }
        public UpdatePassword PasswordForm { get; set; }

        private void InitializeCommands()
        {
            SaveCommand = new RelayCommand(async () => await SavePasswordAsync(), PasswordForm.IsValid);
            ResetCommand = new RelayCommand(async () => await ResetPasswordFormAsync());
        }

        private async Task SavePasswordAsync()
        {
            ContentDialog dialog;

            try
            {
                await _accountService.UpdatePasswordAsync(_account, PasswordForm.NewPassword);
                await PasswordForm.ClearAsync();

                dialog = DialogHelper.GetContentDialog(Tools.Enums.DialogEnum.StandardDialog, "Password changed successfully.");
                await dialog.ShowAsync();
            }
            catch (Exception)
            {
                dialog = DialogHelper.GetContentDialog(Tools.Enums.DialogEnum.StandardDialog, "A problem occured. Try again.");
                await dialog.ShowAsync();
            }
        }

        private async Task ResetPasswordFormAsync() => await PasswordForm.ClearAsync();
    }
}