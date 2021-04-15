using System;
using System.Collections.Generic;
using TicTacToe.BL.DTOs.GameParticipation;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameResultDTO
    {
        public Guid Id { get; set; }
        public int TurnCount { get; set; }
        public List<GameParticipationResultDTO> GameParticipationResults { get; set; }
    }
}