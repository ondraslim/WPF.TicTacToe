using System;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameResultDTO
    {
        public Guid GameId { get; set; }
        public int TurnCount { get; set; }
        public Guid WinnerId { get; set; }
    }
}