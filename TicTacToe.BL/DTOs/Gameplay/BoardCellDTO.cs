using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardCellDTO : GameplayBaseDTO
    {
        private char sign;
        private bool isWinningCell;

        public int Row { get; set; }
        public int Col { get; set; }

        public char Sign
        {
            get => sign;
            set
            {
                sign = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsEmpty));
            }
        }

        public bool IsWinningCell
        {
            get => isWinningCell;
            set
            {
                isWinningCell = value;
                OnPropertyChanged();
            }
        }

        public bool IsEmpty => Sign == default;
    }
}