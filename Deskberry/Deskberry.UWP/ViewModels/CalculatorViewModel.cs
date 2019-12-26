using Deskberry.UWP.Commands;
using Deskberry.UWP.Commands.Generic;
using Deskberry.UWP.Helpers.Models;
using Deskberry.UWP.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Deskberry.UWP.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _displayText;
        private string _expression;
        private string _expressionText;

        private INavigationService _navigationService;

        public CalculatorViewModel()
        {
        }

        public CalculatorViewModel(INavigationService navigationService)
        {
            Expressions = new ObservableCollection<Equation>();
            _navigationService = navigationService;

            CloseSubAppCommand = new RelayCommand(() => CloseSubApp());
            NavigateBackCommand = new RelayCommand(() => NavigateBack());
            ComputeExpressionCommand = new RelayCommand(() => ComputeExpression());
            ComputeExpressionForOneParameterOperationCommand = new RelayCommand(() => ComputeExpressionForOneParameterOperation());
            AddExpressionCommand = new RelayCommand<object>(x => AddExpression(x));
            ClearHistoryCommand = new RelayCommand(() => ClearHistory());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand<object> AddExpressionCommand { get; protected set; }
        public RelayCommand ClearHistoryCommand { get; protected set; }
        public RelayCommand CloseSubAppCommand { get; protected set; }
        public RelayCommand ComputeExpressionCommand { get; protected set; }
        public RelayCommand ComputeExpressionForOneParameterOperationCommand { get; protected set; }
        public RelayCommand NavigateBackCommand { get; protected set; }
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

        private void AddExpression(object result)
        {
            if (result != null)
            {
                var res = result.ToString();

                Expressions.Add(new Equation(_expression, res));
            }
        }

        private void ClearHistory() => Expressions.Clear();

        private void CloseSubApp() => _navigationService.ClearSubAppsWindow();

        private void ComputeExpression() => _expression = ExpressionText + DisplayText;

        private void ComputeExpressionForOneParameterOperation() => _expression = ExpressionText;

        private void NavigateBack() => _navigationService.NavigateBackFromSubApp();
    }
}