using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameplayViewModel : ViewModelBase<GameplayDTO>
    {
        private readonly IGameplayService gameplayService;
        private readonly IGameFacade gameFacade;

        public GameplayDTO Gameplay
        {
            get => ViewModelParameter;
            set => ViewModelParameter = value;
        }

        public ICommand RestartCommand { get; set; }
        public ICommand SurrenderCommand { get; set; }

        public ICommand TakeCellCommand { get; set; }

        public GameplayViewModel(
            GameplayDTO viewModelParameter,
            ICommandFactory commandFactory,
            IGameFacade gameFacade,
            IGameplayService gameplayService)
            : base(viewModelParameter)
        {
            this.gameFacade = gameFacade;
            this.gameplayService = gameplayService;

            RestartCommand = commandFactory.CreateCommand(Restart);
            SurrenderCommand = commandFactory.CreateAsyncCommand(SurrenderAsync);
            TakeCellCommand = commandFactory.CreateCommand<BoardCellDTO>(TakeCell);
        }

        public void Restart()
        {
            Gameplay.CurrentPlayerId = Gameplay.PlayerOne.Id;
            Gameplay.TurnCount = 1;
            Gameplay.Board.ClearCells();
        }

        public async Task SurrenderAsync()
        {
            Gameplay.TurnFinished();
            Gameplay.IsGameOver = true;
            Gameplay.CurrentPlayer.IsWinner = true;

            await SaveResultAsync();
        }

        // TODO: add draw option
        public void TakeCell(BoardCellDTO selectedCell)
        {
            var cell = Gameplay.Board.GetCell(selectedCell.Row, selectedCell.Col);
            cell.Sign = Gameplay.CurrentPlayer.Sign;

            var isWin = gameplayService.CheckIsWin(Gameplay.Board, cell);
            if (isWin)
            {
                Gameplay.IsGameOver = true;
                Gameplay.CurrentPlayer.IsWinner = true;
            }

            Gameplay.TurnFinished();
        }

        private async Task SaveResultAsync()
        {
            var result = new GameResultDTO
            {
                GameId = Gameplay.GameId,
                TurnCount = Gameplay.TurnCount,
                WinnerId = Gameplay.CurrentPlayerId
            };

            await gameFacade.SaveGameResultAsync(result);
        }
    }
}