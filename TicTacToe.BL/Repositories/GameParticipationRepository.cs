using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.Data.Models;
using TicTacToe.Infrastructure.EntityFramework;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Repositories
{
    public class GameParticipationRepository : EntityFrameworkRepository<GameParticipation, Guid>, IGameParticipationRepository
    {
        public GameParticipationRepository(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        public Task<List<GameParticipation>> GetGameParticipationAsync(Guid gameId)
        {
            return Context.Set<GameParticipation>()
                .Where(g => g.GameId == gameId)
                .Include(gp => gp.User)
                .ToListAsync();
        }
    }
}