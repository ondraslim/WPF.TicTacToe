﻿using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.Factories;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.Core.ViewModels
{
    public class GameSetupViewModel : ViewModelBase
    {
        private readonly IGameFacade gameFacade;

        public GameCreateDTO GameCreateModel { get; set; } = new();

        public ICommand CreateGameCommand { get; set; }

        // TODO: fix visibility converter
        public bool IsSoloGameTypeSelected => GameCreateModel.Type == GameType.Solo;
        public bool IsMultiplayerGameTypeSelected => GameCreateModel.Type == GameType.Multiplayer;

        public GameSetupViewModel(ICommandFactory commandFactory, IGameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
            CreateGameCommand = commandFactory.CreateAsyncCommand(CreateGameAsync);
        }

        private async Task CreateGameAsync()
        {
            var createdGame = await gameFacade.CreateGameAsync(GameCreateModel);
        }

    }
}