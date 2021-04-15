using System;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class BoardPositionDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Guid? TakeByPlayerId { get; set; }

        public bool IsTaken => TakeByPlayerId is not null;
    }
}