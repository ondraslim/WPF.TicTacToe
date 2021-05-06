namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardCellDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Sign { get; set; }

        public bool IsEmpty => string.IsNullOrEmpty(Sign);
    }
}