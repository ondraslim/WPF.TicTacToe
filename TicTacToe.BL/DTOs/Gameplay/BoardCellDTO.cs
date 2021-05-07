using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardCellDTO : GameplayBaseDTO
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public char Sign { get; set; }

        public bool IsWinningCell { get; set; }

        public bool IsEmpty => Sign == default;
    }
}