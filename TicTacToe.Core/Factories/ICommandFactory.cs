using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Core.Commands.Interfaces;
using TicTacToe.Core.Factories.Common;

namespace TicTacToe.Core.Factories
{
    public interface ICommandFactory : IFactory
    {
        ICommand CreateCommand(Action execute, Expression<Func<bool>> canExecute = null);
        ICommand CreateCommand<T>(Action<T> execute, Expression<Func<T, bool>> canExecute = null);
        IAsyncCommand CreateAsyncCommand(Func<Task> execute, Func<bool> canExecute = null);
        IAsyncCommand<T> CreateAsyncCommand<T>(Func<T, Task> execute, Func<bool> canExecute = null);
    }
}