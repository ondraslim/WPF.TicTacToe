using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.GameParticipation;
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
        private readonly IGameParticipationRepository gameParticipationRepository;
        private readonly IMapper mapper;

        public GameFacade(
            IUnitOfWorkProvider unitOfWorkProvider, 
            IGameRepository gameRepository, 
            IMapper mapper, 
            IGameParticipationRepository gameParticipationRepository) 
            : base(unitOfWorkProvider)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
            this.gameParticipationRepository = gameParticipationRepository;
        }

        public async Task<GameDTO> CreateGameAsync(GameCreateDTO game)
        {
            var gameEntity = mapper.Map<Game>(game);

            using var uow = UnitOfWorkProvider.Create();

            var gameId = await gameRepository.CreateAsync(gameEntity);
            var createdGame = await gameRepository.GetByIdAsync(gameId);
            await uow.CommitAsync();

            return mapper.Map<GameDTO>(createdGame);
        }

        public async Task AddGameParticipationAsync(IList<GameParticipationSetupDTO> gameParticipationList)
        {
            using var uow = UnitOfWorkProvider.Create();

            foreach (var dto in gameParticipationList)
            {
                var entity = mapper.Map<GameParticipation>(dto);
                await gameParticipationRepository.CreateAsync(entity);
            }

            await uow.CommitAsync();
        }

        public async Task<GameplayDTO> StartGameAsync(Guid gameId)
        {
            Game game;
            using (UnitOfWorkProvider.Create())
            {
                game = await gameRepository.GetByIdAsync(gameId, nameof(Game.GameParticipation));
            }

            return mapper.Map<GameplayDTO>(game);
        }

        public void SaveGameResult(GameDTO game)
        {
            throw new NotImplementedException();
        }

        public List<UserGameListDTO> GetLastGamesOfUser(int gameCountRequested)
        {
            throw new System.NotImplementedException();
        }
    }
}