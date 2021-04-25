using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace TicTacToe.Infrastructure.EntityFramework.UnitOfWork
{
    public class EntityFrameworkUnitOfWork : Infrastructure.UnitOfWork.UnitOfWork
    {
        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkUnitOfWork"/> class.
        /// </summary>
        public EntityFrameworkUnitOfWork(Func<DbContext> dbContextFactory)
        {
            Context = dbContextFactory?.Invoke() ?? throw new ArgumentException("Db context factory can't be null!");
        }

        /// <summary>
        /// commits changes
        /// </summary>
        /// <returns></returns>
        protected override async Task CommitCore()
        {
            await Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}
