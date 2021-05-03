using System;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameResultDTO
    {
        public Guid Id { get; set; }
        public int TurnCount { get; set; }
    }
}