using System;
using System.Collections.Generic;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameDTO
    {
        public Guid Id { get; set; }

        public GameType Type { get; set; }
        public AiDifficulty Difficulty { get; set; }

        public int BoardSize { get; set; }

        public List<GameParticipationDTO> GameParticipationList { get; set; }
    }
}