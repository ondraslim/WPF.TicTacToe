using System.Windows.Input;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameplayViewModel : ViewModelBase<GameplayDTO>
    {
        private readonly IGameFacade gameFacade;
        private readonly INavigationService navigationService;

        public GameplayDTO Gameplay
        {
            get => ViewModelParameter; 
            set => ViewModelParameter = value;
        }

        public ICommand TakeCellCommand { get; set; }

        public GameplayViewModel(
            GameplayDTO viewModelParameter,
            ICommandFactory commandFactory,
            IGameFacade gameFacade, 
            INavigationService navigationService)
            : base(viewModelParameter)
        {
            this.gameFacade = gameFacade;
            this.navigationService = navigationService;

            TakeCellCommand = commandFactory.CreateCommand<BoardCellDTO>(TakeCell);
        }

        public void TakeCell(BoardCellDTO selectedCell)
        {
            var cell = Gameplay.Board.GetCell(selectedCell.X, selectedCell.Y);
            cell.Sign = Gameplay.CurrentPlayer.Sign;

            Gameplay.TurnFinished();
        }
    }
}