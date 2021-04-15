using System;

namespace TicTacToe.BL.DTOs.GameParticipation
{
    public class GameParticipationResultDTO
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }
        public bool IsWinner { get; set; }
    }
}