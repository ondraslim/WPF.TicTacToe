using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.Builders.Interfaces;
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
        private readonly IGamePlayBuilder gamePlayBuilder;

        private Game game = new()
        {
            Id = Guid.NewGuid(), 
            GameParticipation = new List<GameParticipation>()
        };

        public GameFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            IGameRepository gameRepository,
            IMapper mapper,
            IGameParticipationRepository gameParticipationRepository, 
            IGamePlayBuilder gamePlayBuilder)
            : base(unitOfWorkProvider)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
            this.gameParticipationRepository = gameParticipationRepository;
            this.gamePlayBuilder = gamePlayBuilder;
        }

        public async Task<GameDTO> CreateGameAsync(GameCreateDTO game)
        {
            this.game = mapper.Map<Game>(game);
            this.game.Id = Guid.NewGuid();
            //using var uow = UnitOfWorkProvider.Create();

            //var gameId = await gameRepository.CreateAsync(gameEntity);
            //var createdGame = await gameRepository.GetByIdAsync(gameId);
            //await uow.CommitAsync();

            return mapper.Map<GameDTO>(this.game);
        }

        public async Task AddGameParticipationAsync(IList<GameParticipationSetupDTO> gameParticipationList)
        {
            //using var uow = UnitOfWorkProvider.Create();

            //foreach (var dto in gameParticipationList)
            //{
            //    var entity = mapper.Map<GameParticipation>(dto);
            //    await gameParticipationRepository.CreateAsync(entity);
            //}

            //await uow.CommitAsync();

            foreach (var dto in gameParticipationList)
            {
                var e = mapper.Map<GameParticipation>(dto);
                e.Id = Guid.NewGuid();
                game.GameParticipation.Add(e);
            }
        }

        public async Task<GameplayDTO> StartGameAsync(Guid gameId)
        {
            //Game game;
            //using (UnitOfWorkProvider.Create())
            //{
            //    game = await gameRepository.GetByIdAsync(gameId, nameof(Game.GameParticipation));
            //}


            var gameplayDto = gamePlayBuilder
                .CreateGameplay(game.Id, game.Type)
                .PrepareBoard(game.BoardSize)
                .AddPlayers(game.GameParticipation)
                .Build();

            return gameplayDto;
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