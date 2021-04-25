using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Infrastructure.Entities;
using TicTacToe.Infrastructure.EntityFramework.UnitOfWork;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.Infrastructure.EntityFramework
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private readonly IUnitOfWorkProvider provider;

        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        protected DbContext Context => ((EntityFrameworkUnitOfWork) provider.GetUnitOfWorkInstance()).Context;

        public EntityFrameworkRepository(IUnitOfWorkProvider provider)
        {
            this.provider = provider;
        }

        public TKey Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public void Delete(TKey id)
        {
            var entity = Context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id, params string[] includes)
        {
            var ctx = Context.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                ctx = ctx.Include(include);
            }

            return await ctx.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public void Update(TEntity entity)
        {
            var foundEntity = Context.Set<TEntity>().Find(entity.Id);
            Context.Entry(foundEntity).CurrentValues.SetValues(entity);
        }
    }
}