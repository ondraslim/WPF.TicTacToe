using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.Core.ViewModels
{
    public class GameSetupViewModel : ViewModelBase
    {
        private readonly IGameFacade gameFacade;
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly INavigationService navigationService;

        public GameCreateDTO GameCreateModel { get; set; } = new();

        public ICommand CreateGameCommand { get; set; }

        // TODO: fix visibility converter
        public bool IsSoloGameTypeSelected => GameCreateModel.Type == GameType.Solo;
        public bool IsMultiplayerGameTypeSelected => GameCreateModel.Type == GameType.Multiplayer;

        public GameSetupViewModel(
            ICommandFactory commandFactory,
            IGameFacade gameFacade,
            ICurrentUserProvider currentUserProvider,
            INavigationService navigationService)
        {
            this.gameFacade = gameFacade;
            this.currentUserProvider = currentUserProvider;
            this.navigationService = navigationService;
            CreateGameCommand = commandFactory.CreateAsyncCommand(CreateGameAsync);
        }

        private async Task CreateGameAsync()
        {
            GameCreateModel.GameCreatorId = currentUserProvider.CurrentUser.Id;

            // TODO: temporary
            GameCreateModel.GameCreatorId = Guid.Empty;

            var createdGame = await gameFacade.CreateGameAsync(GameCreateModel);

            // TODO: pick players and symbols
            //navigationService.NavigateTo<GameplayViewModel, GameplayDTO>(createdGame);
        }

    }
}