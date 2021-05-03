using System.Threading.Tasks;
using TicTacToe.Infrastructure.Entities;

namespace TicTacToe.Infrastructure
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// get entity by id
        /// </summary>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// get entity by id with includes
        /// </summary>
        Task<TEntity> GetByIdAsync(TKey id, params string[] includes);

        /// <summary>
        /// Persists the given entity.
        /// </summary>
        Task<TKey> CreateAsync(TEntity entity);

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes an entity with the given id.
        /// </summary>
        Task DeleteAsync(TKey id);
    }
}
