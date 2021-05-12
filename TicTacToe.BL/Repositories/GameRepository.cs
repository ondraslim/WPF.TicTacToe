using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.Data.Models;
using TicTacToe.Infrastructure.EntityFramework;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Repositories
{
    public class GameRepository : EntityFrameworkRepository<Game, Guid>, IGameRepository
    {
        public GameRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        public Task<List<Game>> GetLongestGameListAsync(int count)
        {
            return Context.Set<Game>()
                .OrderByDescending(g => g.TurnCount)
                .Include(g => g.GameParticipation)
                .ThenInclude(gp => gp.User)
                .Where(u => u.GameParticipation.Any(gp => gp.IsWinner))
                .Take(count)
                .ToListAsync();
        }

        public Task<List<UserGameCountListDTO>> GetMostGamesUserListAsync(int count)
        {
            return Context.Set<User>()
                .OrderByDescending(u => u.GameParticipation.Count)
                .Where(u => u.GameParticipation.Any(gp => gp.IsWinner))
                .Take(count)
                .Select(u => new UserGameCountListDTO
                {
                    UserId = u.Id, 
                    UserName = u.Name,
                    GameCount = u.GameParticipation.Count
                })
                .ToListAsync();
        }

        public Task<List<UserWinRateListDTO>> GetBestWinRateUserListAsync(int count)
        {
            return Context.Set<User>()
                .OrderByDescending(u => 100.0 * u.GameParticipation.Count(g => g.IsWinner) / u.GameParticipation.Count)
                .Where(u => u.GameParticipation.Any(gp => gp.IsWinner))
                .Take(count)
                .Select(u => new UserWinRateListDTO
                {
                    UserId = u.Id, 
                    UserName = u.Name,
                    GameCount = u.GameParticipation.Count,
                    WinRate = 100.0 * u.GameParticipation.Count(g => g.IsWinner) / u.GameParticipation.Count
                })
                .ToListAsync();
        }
    }
}