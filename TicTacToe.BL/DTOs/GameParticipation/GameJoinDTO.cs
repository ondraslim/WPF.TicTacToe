using System;

namespace TicTacToe.BL.DTOs.GameParticipation
{
    public class GameJoinDTO
    {
        public Guid JoiningUserId { get; set; }
        public Guid GameId { get; set; }
        public string AccessCode { get; set; }
    }
}