using System.Collections.Generic;
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


        public List<LongGameListDTO> GetLongestGamesListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
            
            return new()
            {
                new LongGameListDTO
                {
                    Opponent = "Opponent1",
                    TurnCount = 42,
                    Type = GameType.Multiplayer
                },
                new LongGameListDTO
                {
                    Opponent = "Opponent2",
                    TurnCount = 39,
                    Type = GameType.Multiplayer
                },
                new LongGameListDTO
                {
                    Opponent = "AI",
                    TurnCount = 32,
                    Type = GameType.Solo
                }
            };
        }

        public List<UserGameCountListDTO> GetMostGamesUserListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
         
            return new()
            {
                new UserGameCountListDTO
                {
                    UserName = "Me",
                    GameCount = 123
                },
                new UserGameCountListDTO
                {
                    UserName = "Hubert",
                    GameCount = 101
                },
                new UserGameCountListDTO
                {
                    UserName = "Huberta",
                    GameCount = 44
                },
            };
        }

        public List<UserWinRateListDTO> GetBestWinRateUserListAsync()
        {
            using var uow = UnitOfWorkProvider.Create();
           
            return new()
            {
                new UserWinRateListDTO
                {
                    UserName = "Me",
                    GamesPlayedCount = 100,
                    WinRate = 80
                },
                new UserWinRateListDTO
                {
                    UserName = "Hubert",
                    GamesPlayedCount = 50,
                    WinRate = 60
                },
                new UserWinRateListDTO
                {
                    UserName = "Huberta",
                    GamesPlayedCount = 40,
                    WinRate = 60
                }
            };
        }
    }
}