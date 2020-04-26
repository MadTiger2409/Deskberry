using System;
using System.Windows.Input;

namespace Deskberry.Helpers.Commands.Generic
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute.Invoke((T)parameter);

        public virtual void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute((T)parameter);
            }
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}