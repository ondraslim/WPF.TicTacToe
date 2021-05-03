using System;
using System.Threading.Tasks;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<Guid> CreateAsync(Game entity);
        Task DeleteAsync(Guid id);
        Task<Game> GetByIdAsync(Guid id);
        Task<Game> GetByIdAsync(Guid id, params string[] includes);
        Task UpdateAsync(Game entity);
    }
}