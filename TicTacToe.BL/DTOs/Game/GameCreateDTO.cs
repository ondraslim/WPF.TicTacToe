using System.Collections.Generic;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.Data.Entities.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameCreateDTO
    {
        public GameType Type { get; set; }
        public string AccessCode { get; set; }

        public int BoardSize { get; set; }

        public List<GameParticipationDTO> GameParticipation { get; set; }
    }
}