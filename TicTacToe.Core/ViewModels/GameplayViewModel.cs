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

            SurrenderCommand = commandFactory.CreateAsyncCommand(SurrenderAsync);
            TakeCellCommand = commandFactory.CreateAsyncCommand<BoardCellDTO>(TakeCell);

            StartGameplay();
        }

        private void StartGameplay()
        {
            Gameplay.IsActive = true;
            OnPropertyChanged(nameof(Gameplay.IsActive));
        }

        public async Task SurrenderAsync()
        {
            Gameplay.TurnFinished();
            Gameplay.IsActive = false;
            Gameplay.CurrentPlayer.IsWinner = true;

            await SaveResultAsync();
        }

        // TODO: add draw option
        public async Task TakeCell(BoardCellDTO selectedCell)
        {
            var cell = Gameplay.Board.GetCell(selectedCell.Row, selectedCell.Col);
            cell.Sign = Gameplay.CurrentPlayer.Sign;

            var isWin = gameplayService.CheckIsWin(Gameplay.Board, cell);
            if (isWin)
            {
                Gameplay.IsActive = false;
                Gameplay.CurrentPlayer.IsWinner = true;

                await SaveResultAsync();
            }
            else if (Gameplay.IsDraw)
            {
                Gameplay.IsActive = false;
                await SaveResultAsync();
            }
            else
            {
                Gameplay.TurnFinished();
            }
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