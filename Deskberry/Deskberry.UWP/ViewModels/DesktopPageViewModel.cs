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
        #endregion
        #region Commands
        public RelayCommand OpenBrowerCommand { get; private set; }
        public RelayCommand OpenNotesCommand { get; private set; }
        public RelayCommand ClearDesktopWinddowCommand { get; private set; }
        #endregion

        public DesktopPageViewModel() { }

        public DesktopPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            OpenBrowerCommand = new RelayCommand(() => OpenBrowser());
            OpenNotesCommand = new RelayCommand(() => OpenNotes());
            ClearDesktopWinddowCommand = new RelayCommand(() => ClearDesktopWindow());
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

        private void ClearDesktopWindow()
        {
            _navigationService.ClearSubAppsWindow();
        }
        #endregion
    }
}
