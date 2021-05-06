using System;
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
    }
}