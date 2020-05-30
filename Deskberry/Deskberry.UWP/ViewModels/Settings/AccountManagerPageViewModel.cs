﻿using Deskberry.Common.Models;
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
            InitializeCommands();
        }

        public AccountManagerPageViewModel(IAccountService accountService) : this()
        {
            _accountService = accountService;
        }

        public RelayCommand DeleteCommand { get; protected set; }
        public RelayCommand CreateCommand { get; protected set; }

        public ObservableCollection<Account> Accounts { get; set; }

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

        private async Task DeleteSelectedAccountAsync()
        {
            //TODO Implement rest of this method

            await _accountService.DeleteAccountAsync(SelectedAccount.Id);
        }

        private async Task CreateAccountAsync()
        {
            //TODO Implement rest of this method

            await _accountService.AddAccountAsync(new CreateAccount());
        }

        private void InitializeCommands()
        {
            DeleteCommand = new RelayCommand(async () => await DeleteSelectedAccountAsync());
            CreateCommand = new RelayCommand(async () => await CreateAccountAsync());
        }
    }
}