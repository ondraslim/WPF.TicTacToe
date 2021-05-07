using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardCellDTO : GameplayBaseDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Sign { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(Sign);
    }
}