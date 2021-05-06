using System;

namespace TicTacToe.BL.DTOs.GameParticipation
{
    public class GameParticipationSetupDTO
    {
        public Guid GameId { get; set; }
        public Guid? UserId { get; set; }
        public bool IsFirst { get; set; }
        public string ExternalPlayerName { get; set; }
    }
}