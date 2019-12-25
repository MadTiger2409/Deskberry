using Deskberry.Tools.Services.Interfaces;
using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using Deskberry.UWP.Views;

namespace Deskberry.UWP.ViewModels
{
    public class DesktopPageViewModel
    {
        private IAccountService _accountService;
        private INavigationService _navigationService;

        public DesktopPageViewModel()
        {
        }

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

        public RelayCommand ClearDesktopWinddowCommand { get; private set; }
        public RelayCommand LogOutCommand { get; private set; }
        public RelayCommand OpenBrowerCommand { get; private set; }
        public RelayCommand OpenCalculatorCommand { get; private set; }
        public RelayCommand OpenNotesCommand { get; private set; }

        private void ClearDesktopWindow() => _navigationService.ClearSubAppsWindow();

        private void LogOut()
        {
            _accountService.LogOut();
            _navigationService.NavigateBack();
        }

        private void OpenBrowser() => _navigationService.NavigateToSubApp(typeof(BrowserPage));

        private void OpenCalculator() => _navigationService.NavigateToSubApp(typeof(CalculatorPage));

        private void OpenNotes() => _navigationService.NavigateToSubApp(typeof(NotesPage));
    }
}