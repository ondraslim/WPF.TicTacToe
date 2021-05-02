using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.Infrastructure.UnitOfWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// List of actions done if commit is successful
        /// </summary>
        private readonly List<Action> postCommitActions = new();

        /// <summary>
        /// Commits the changes inside this instance of UOW
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await CommitCore();
            foreach (var action in postCommitActions)
            {
                action();
            }
            postCommitActions.Clear();
        }

        public void RegisterAction(Action action)
        {
            postCommitActions.Add(action);
        }

        public void RegisterMultipleActions(IEnumerable<Action> actions)
        {
            postCommitActions.AddRange(actions);
        }

        /// <summary>
        /// Performs the real commit work.
        /// </summary>
        protected abstract Task CommitCore();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}
