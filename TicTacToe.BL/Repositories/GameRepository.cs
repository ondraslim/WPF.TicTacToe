using System;
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
    }
}