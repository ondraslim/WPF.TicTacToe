using System;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Game
{
    public class GameCreateDTO
    {
        private GameType type = GameType.Solo;

        public GameType Type
        {
            get => type;
            set
            {
                type = value;
                Difficulty = type == GameType.Solo ? AiDifficulty.Normal : AiDifficulty.None;
            }
        }

        public AiDifficulty Difficulty { get; set; } = AiDifficulty.Normal;

        public int BoardSize { get; set; } = 20;

        public Guid GameCreatorId { get; set; }
    }
}