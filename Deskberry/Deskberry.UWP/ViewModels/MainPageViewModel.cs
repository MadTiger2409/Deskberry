using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deskberry.SQLite.Models;

namespace Deskberry.UWP.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Members
        private Account _selectedAccount;
        private bool _isLoginEnabled;
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

        public MainPageViewModel()
        {

        }
    }
}
