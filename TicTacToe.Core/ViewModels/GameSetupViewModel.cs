using System;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameSetupViewModel : ViewModelBase
    {
        private readonly IGameFacade gameFacade;
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly INavigationService navigationService;

        public GameCreateDTO GameCreateModel { get; set; } = new();

        public ICommand CreateGameCommand { get; set; }

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
            var createdGame = await gameFacade.CreateGameAsync(GameCreateModel);

            navigationService.NavigateTo<GameParticipationSetupViewModel, GameDTO>(viewModelParameter: createdGame);
        }

    }
}