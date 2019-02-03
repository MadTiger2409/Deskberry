using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Models;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using Windows.ApplicationModel;

namespace Deskberry.UWP.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        public Account _selectedAccount;
        public string _password;
        public bool _isLoginEnabled;
        #endregion

        #region Injected
        private IAccountService _accountService;
        private INavigationService _navigationService;
        #endregion

        #region Commands
        public RelayCommand LoginCommand { get; private set; }
        #endregion

        #region Properties
        public ObservableCollection<Account> Accounts { get; set; }

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

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                    return;

                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
        #endregion

        public MainPageViewModel() { }

        public MainPageViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            LoginCommand = new RelayCommand(() => Login());
            Accounts = LoadAccounts();
            SelectedAccount = Accounts.FirstOrDefault();
        }

        #region PrivateMethods
        private ObservableCollection<Account> LoadAccounts()
        {
            var accountsCollection = new ObservableCollection<Account>();
            var accounts = _accountService.GetAccountsAssync().GetAwaiter().GetResult();

            foreach (var account in accounts)
            {
                accountsCollection.Add(account);
            }

            return accountsCollection;
        }

        private async void Login()
        {
            var areValid = await _accountService.AreCredentialsValid(SelectedAccount, Password);
            if (areValid == true)
            {
                _navigationService.NavigateTo(typeof(DesktopPage));
            }
        }
        #endregion
    }
}
