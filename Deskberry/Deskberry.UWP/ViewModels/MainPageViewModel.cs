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
using Windows.ApplicationModel;

namespace Deskberry.UWP.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Members
        private IAccountService _accountService;
        public Account _selectedAccount;
        public bool _isLoginEnabled;
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
        #endregion

        public MainPageViewModel() { }

        public MainPageViewModel(IAccountService accountService)
        {
            _accountService = accountService;
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
        #endregion
    }
}
