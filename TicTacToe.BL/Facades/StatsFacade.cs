using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Facades.Common;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.Data.Models.Enums;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class StatsFacade : FacadeBase, IStatsFacade
    {
        private readonly IGameRepository gameRepository;

        public StatsFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            IGameRepository gameRepository) 
            : base(unitOfWorkProvider)
        {
            this.gameRepository = gameRepository;
        }


        public async Task<List<LongGameListDTO>> GetLongestGamesListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
            var longestGames = await gameRepository.GetLongestGameListAsync(10);

            return longestGames
                .Select(g => new LongGameListDTO
                {
                    Id = g.Id,
                    TurnCount = g.TurnCount,
                    Type = g.Type,
                    Players = g.GameParticipation.Select(gp => gp.User?.Name ?? gp.ExternalPlayerName).ToList()
                })
                .ToList();
        }

        public async Task<List<UserGameCountListDTO>> GetMostGamesUserListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
            return await gameRepository.GetMostGamesUserListAsync(10);
        }

        public async Task<List<UserWinRateListDTO>> GetBestWinRateUserListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
            return await gameRepository.GetBestWinRateUserListAsync(10);
        }
    }
}