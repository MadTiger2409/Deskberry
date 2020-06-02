using Deskberry.Common.Models;
using Deskberry.Helpers.Commands;
using Deskberry.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.Helpers;
using Deskberry.CommandValidation.CommandObjects.Account;
using System.ComponentModel;
using Deskberry.UWP.Helpers;
using Deskberry.Tools.Enums;

namespace Deskberry.UWP.ViewModels.Settings
{
    public class AccountManagerPageViewModel : INotifyPropertyChanged
    {
        private readonly IAccountService _accountService;

        private Account _selectedAccount;

        public AccountManagerPageViewModel()
        {
            Accounts = new ObservableCollection<Account>();
            SelectedAccount = new Account();

            InitializeCommands();
        }

        public AccountManagerPageViewModel(IAccountService accountService) : this()
        {
            _accountService = accountService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Account> Accounts { get; set; }
        public RelayCommand CreateCommand { get; protected set; }
        public RelayCommand DeleteCommand { get; protected set; }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                if (value == _selectedAccount)
                    return;

                _selectedAccount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAccount)));
            }
        }

        public async Task InitializeDataAsync()
        {
            Accounts.Clear();
            Accounts.AddRange(await _accountService.GetAsync());
            SelectedAccount = Accounts.FirstOrDefault();
            DeleteCommand.RaiseCanExecuteChanged();
        }

        private bool CanCreateAccount() => Accounts.Count < 4;

        private bool CanDeleteAccount() => Accounts.Count > 1;

        private async Task CreateAccountAsync()
        {
            var dialog = DialogHelper.GetContentDialog(DialogEnum.CreateUserDialog, new CreateAccount());
            await dialog.ShowAsync();

            // await _accountService.AddAccountAsync(new CreateAccount() { Login = "Test", Password = "Test" });
            await InitializeDataAsync();
        }

        private async Task DeleteSelectedAccountAsync()
        {
            var acccountToRemove = SelectedAccount;
            await _accountService.DeleteAccountAsync(SelectedAccount.Id);
            Accounts.Remove(SelectedAccount);
            DeleteCommand.RaiseCanExecuteChanged();
        }

        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand(async () => await DeleteSelectedAccountAsync(), CanDeleteAccount);
            CreateCommand = new RelayCommand(async () => await CreateAccountAsync(), CanCreateAccount);
        }
    }
}