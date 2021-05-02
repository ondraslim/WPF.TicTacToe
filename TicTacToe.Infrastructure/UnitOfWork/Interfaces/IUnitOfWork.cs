using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicTacToe.Infrastructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes made within this unit of work.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Registers an action, which is executed if and only if commit is succesfull.
        /// </summary>
        void RegisterAction(Action action);

        /// <summary>
        /// Registers an action, which is executed if and only if commit is succesfull.
        /// </summary>
        void RegisterMultipleActions(IEnumerable<Action> actions);
    }
}
