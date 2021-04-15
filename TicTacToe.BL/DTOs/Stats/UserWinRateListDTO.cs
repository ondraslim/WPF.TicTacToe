using System;

namespace TicTacToe.BL.DTOs.Stats
{
    public class UserWinRateListDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public int GamesPlayedCount { get; set; }
        public double WinRate { get; set; }
    }
}