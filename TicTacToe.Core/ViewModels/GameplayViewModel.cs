using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameplayViewModel : ViewModelBase<GameplayDTO>
    {
        public GameplayViewModel(GameplayDTO viewModelParameter) : base(viewModelParameter)
        {
        }
    }
}