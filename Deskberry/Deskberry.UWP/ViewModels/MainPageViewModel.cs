using Deskberry.SQLite.Models;
using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Deskberry.UWP.ViewModels
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public bool _isWarningVisible;
        public string _password;
        public Account _selectedAccount;

        private IAccountService _accountService;
        private INavigationService _navigationService;

        public MainPageViewModel()
        {
        }

        public MainPageViewModel(IAccountService accountService, INavigationService navigationService)
        {
            _accountService = accountService;
            _navigationService = navigationService;

            LoginCommand = new RelayCommand(() => Login());
            Accounts = LoadAccounts();
            SelectedAccount = Accounts.FirstOrDefault();
            IsWarningVisible = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Account> Accounts { get; set; }

        public bool IsWarningVisible
        {
            get { return _isWarningVisible; }
            set
            {
                if (value == _isWarningVisible)
                    return;

                _isWarningVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsWarningVisible)));
            }
        }

        public RelayCommand LoginCommand { get; private set; }

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

        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                if (value == _selectedAccount)
                    return;

                _selectedAccount = value;
                IsWarningVisible = false;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAccount)));
            }
        }

        private ObservableCollection<Account> LoadAccounts()
        {
            var accounts = _accountService.GetAsync().GetAwaiter().GetResult();
            var accountsCollection = new ObservableCollection<Account>(accounts);

            return accountsCollection;
        }

        private async void Login()
        {
            var canLogin = await _accountService.CanLogInAsync(SelectedAccount, Password);
            IsWarningVisible = !canLogin;
            if (canLogin == true)
            {
                _navigationService.NavigateTo(typeof(DesktopPage));
            }
        }
    }
}