using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Core.Commands;
using TicTacToe.Core.Commands.Interfaces;

namespace TicTacToe.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(Action execute, Expression<Func<bool>> canExecute = null)
        {
            return new Command(execute, canExecute?.Compile());
        }

        public ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>> canExecute = null)
        {
            return new Command<T>(execute, canExecute?.Compile());
        }

        public IAsyncCommand CreateAsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            return new AsyncCommand(execute, canExecute);
        }

        public IAsyncCommand<T> CreateAsyncCommand<T>(Func<T, Task> execute, Func<bool> canExecute = null)
        {
            return new AsyncCommand<T>(execute, canExecute);
        }
    }
}