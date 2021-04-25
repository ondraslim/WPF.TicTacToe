using System;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Stats
{
    public class LongGameListDTO
    {
        public Guid Id { get; set; }

        public GameType Type { get; set; }
        public string Opponent { get; set; }
        public int TurnCount { get; set; }
    }
}