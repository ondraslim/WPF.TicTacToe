using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Stats;
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
        Task<List<Game>> GetLongestGameListAsync(int count);
        Task<List<UserGameCountListDTO>> GetMostGamesUserListAsync(int count);
        Task<List<UserWinRateListDTO>> GetBestWinRateUserListAsync(int count);
    }
}