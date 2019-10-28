using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers.Models;
using Deskberry.UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deskberry.UWP.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Fields
        private string _displayText;
        private string _expressionText;
        private string _expression;
        #endregion

        #region Injected
        private INavigationService _navigationService;
        #endregion

        #region Commands
        public RelayCommand CloseSubAppCommand { get; private set; }
        public RelayCommand NavigateBackCommand { get; private set; }
        public RelayCommand ComputeExpressionCommand { get; private set; }
        public RelayCommand ComputeExpressionForOneParameterOperationCommand { get; private set; }
        public RelayCommand<object> AddExpressionCommand { get; protected set; }
        #endregion

        #region Properties
        public ObservableCollection<Equation> Expressions { get; set; }

        public string DisplayText
        {
            get { return _displayText; }
            set
            {
                _displayText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayText)));
            }
        }

        public string ExpressionText
        {
            get { return _expressionText; }
            set
            {
                _expressionText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExpressionText)));
            }
        }
        #endregion

        public CalculatorViewModel() { }

        public CalculatorViewModel(INavigationService navigationService)
        {
            Expressions = new ObservableCollection<Equation>();

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
            ComputeExpressionCommand = new RelayCommand(() => ComputeExpression());
            ComputeExpressionForOneParameterOperationCommand = new RelayCommand(() => ComputeExpressionForOneParameterOperation());
            AddExpressionCommand = new RelayCommand<object>(x => AddExpression(x));
        }

        #region PrivateMethods
        private void CloseSubApp() => _navigationService.ClearSubAppsWindow();

        private void NavigateBack() => _navigationService.NavigateBackFromSubApp();

        private void ComputeExpression() => _expression = ExpressionText + DisplayText;

        private void ComputeExpressionForOneParameterOperation() => _expression = ExpressionText;

        private void AddExpression(object result)
        {
            if (result != null)
            {
                var res = result.ToString();

                Expressions.Add(new Equation(_expression, res));
            }
        }
        #endregion
    }
}
