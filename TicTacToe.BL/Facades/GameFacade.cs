using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Common;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Repositories.Interfaces;
using TicTacToe.Data.Models;
using TicTacToe.Infrastructure.UnitOfWork.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class GameFacade : FacadeBase, IGameFacade
    {
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public GameFacade(
            IUnitOfWorkProvider unitOfWorkProvider, 
            IGameRepository gameRepository, 
            IMapper mapper) 
            : base(unitOfWorkProvider)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        public async Task<GameDTO> CreateGameAsync(GameCreateDTO game)
        {
            var gameEntity = mapper.Map<Game>(game);

            using var uow = UnitOfWorkProvider.Create();

            var gameId = await gameRepository.CreateAsync(gameEntity);
            var createdGame = await gameRepository.GetByIdAsync(gameId);

            return mapper.Map<GameDTO>(createdGame);
        }

        public Task<GameplayDTO> StartGame(GameDTO game)
        {
            throw new System.NotImplementedException();
        }

        public void SaveGameResult(GameDTO game)
        {
            throw new System.NotImplementedException();
        }

        public List<UserGameListDTO> GetLastGamesOfUser(int gameCountRequested)
        {
            throw new System.NotImplementedException();
        }
    }
}