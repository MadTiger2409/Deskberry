using System;
using System.Windows.Input;

namespace Deskberry.Helpers.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _TargetCanExecuteMethod;
        private readonly Action _TargetExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged = delegate { };

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter) => _TargetExecuteMethod?.Invoke();

        public void RaiseCanExecuteChanged() => CanExecuteChanged(this, EventArgs.Empty);
    }
}