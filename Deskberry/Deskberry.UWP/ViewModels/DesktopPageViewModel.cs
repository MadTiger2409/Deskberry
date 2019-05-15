using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels
{
    public class DesktopPageViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Injected
        private INavigationService _navigationService;
        private IAccountService _accountService;
        #endregion

        #region Commands
        public RelayCommand OpenBrowerCommand { get; private set; }
        public RelayCommand OpenNotesCommand { get; private set; }
        public RelayCommand OpenCalculatorCommand { get; private set; }
        public RelayCommand ClearDesktopWinddowCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        #endregion

        public DesktopPageViewModel() { }

        public DesktopPageViewModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;

            OpenBrowerCommand = new RelayCommand(() => OpenBrowser());
            OpenNotesCommand = new RelayCommand(() => OpenNotes());
            OpenCalculatorCommand = new RelayCommand(() => OpenCalculator());
            ClearDesktopWinddowCommand = new RelayCommand(() => ClearDesktopWindow());
            LogOutCommand = new RelayCommand(() => LogOut());
        }

        #region PrivateMethods
        private void OpenBrowser()
        {
            _navigationService.NavigateToSubApp(typeof(BrowserPage));
        }

        private void OpenNotes()
        {
            _navigationService.NavigateToSubApp(typeof(NotesPage));
        }

        private void OpenCalculator()
        {
            _navigationService.NavigateToSubApp(typeof(CalculatorPage));
        }

        private void ClearDesktopWindow()
        {
            _navigationService.ClearSubAppsWindow();
        }

        private void LogOut()
        {
            _accountService.LogOut();
            _navigationService.NavigateBack();
        }
        #endregion
    }
}
