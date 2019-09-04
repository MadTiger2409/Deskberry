using Deskberry.UWP.Commands;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels
{
    public class CalculatorViewModel
    {
        #region Commands
        public RelayCommand CloseSubAppCommand { get; private set; }
        public RelayCommand NavigateBackCommand { get; private set; }
        #endregion

        #region Injected
        private INavigationService _navigationService;
        #endregion

        public CalculatorViewModel() { }

        public CalculatorViewModel(INavigationService navigationService)
        {
            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
        }

        #region PrivateMethods
        private void CloseSubApp()
        {
            _navigationService.ClearSubAppsWindow();
        }

        private void NavigateBack()
        {
            _navigationService.NavigateBackFromSubApp();
        }
        #endregion
    }
}
