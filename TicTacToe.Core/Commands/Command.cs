using System;
using System.Windows.Input;

namespace TicTacToe.Core.Commands
{
    public class Command : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public Command(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }

    internal class Command<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool> canExecute;

        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                return canExecute?.Invoke(typedParameter) ?? true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter is T typedParameter)
            {
                execute?.Invoke(typedParameter);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}