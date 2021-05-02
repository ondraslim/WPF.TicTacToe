using System.Collections.Generic;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameCreateDTO
    {
        private GameType type = GameType.Multiplayer;

        public GameType Type
        {
            get => type;
            set
            {
                type = value;
                Difficulty = type == GameType.Solo ? AiDifficulty.Normal : AiDifficulty.None;
            }
        }

        public AiDifficulty Difficulty{ get; set; } = AiDifficulty.Normal;

        public int BoardSize { get; set; } = 20;

        public List<GameParticipationDTO> GameParticipation { get; set; } = new();
    }
}