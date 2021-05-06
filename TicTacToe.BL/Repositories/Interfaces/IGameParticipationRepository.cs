using System;
using System.Threading.Tasks;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Repositories.Interfaces
{
    public interface IGameParticipationRepository
    {
        Task<Guid> CreateAsync(GameParticipation entity);
        Task DeleteAsync(Guid id);
        Task<GameParticipation> GetByIdAsync(Guid id);
        Task<GameParticipation> GetByIdAsync(Guid id, params string[] includes);
        Task UpdateAsync(GameParticipation entity);
    }
}