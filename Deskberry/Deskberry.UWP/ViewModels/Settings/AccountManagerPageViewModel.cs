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

namespace Deskberry.UWP.ViewModels.Settings
{
    public class AccountManagerPageViewModel
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

        public ObservableCollection<Account> Accounts { get; set; }
        public RelayCommand CreateCommand { get; protected set; }
        public RelayCommand DeleteCommand { get; protected set; }

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set { _selectedAccount = value; }
        }

        public async Task InitializeDataAsync()
        {
            Accounts.Clear();
            Accounts.AddRange(await _accountService.GetAsync());
            SelectedAccount = Accounts.FirstOrDefault();
        }

        private bool CanCreateAccount() => Accounts.Count < 4;

        private bool CanDeleteAccount() => Accounts.Count > 1;

        private async Task CreateAccountAsync()
        {
            await _accountService.AddAccountAsync(new CreateAccount() { Login = "Test", Password = "Test" });
            await InitializeDataAsync();
        }

        private async Task DeleteSelectedAccountAsync()
        {
            var acccountToRemove = SelectedAccount;
            await _accountService.DeleteAccountAsync(SelectedAccount.Id);
            Accounts.Remove(SelectedAccount);
        }

        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand(async () => await DeleteSelectedAccountAsync(), CanDeleteAccount);
            CreateCommand = new RelayCommand(async () => await CreateAccountAsync(), CanCreateAccount);
        }
    }
}