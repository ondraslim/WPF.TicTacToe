using System;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class UserGameListDTO
    {
        public Guid Id { get; set; }

        public GameType Type { get; set; }
        public string Opponent { get; set; }
        public bool IsWin { get; set; }
    }
}