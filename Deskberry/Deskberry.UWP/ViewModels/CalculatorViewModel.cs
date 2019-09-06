using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public RelayCommand<object> AddExpressionCommand { get; protected set; }
        #endregion

        #region Injected
        private INavigationService _navigationService;
        #endregion

        #region Properties
        public ObservableCollection<string> Expressions { get; set; }
        #endregion

        public CalculatorViewModel() { }

        public CalculatorViewModel(INavigationService navigationService)
        {
            Expressions = new ObservableCollection<string>();

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
            AddExpressionCommand = new RelayCommand<object>(x => AddExpression(x));
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

        private void AddExpression(object expression) => Expressions.Add((string)expression);
        #endregion
    }
}
