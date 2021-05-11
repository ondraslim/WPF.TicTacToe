using System;
using System.Collections.Generic;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Stats
{
    public class LongGameListDTO
    {
        public Guid Id { get; set; }

        public GameType Type { get; set; }
        public List<string> Players { get; set; }
        public int TurnCount { get; set; }

        public string PlayerNames => string.Join(", ", Players);
    }
}