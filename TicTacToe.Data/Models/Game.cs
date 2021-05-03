using System.Collections.Generic;
using TicTacToe.Data.Models.Base;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.Data.Models
{
    public class Game : EntityBase
    {
        public GameType Type { get; set; }
        public AiDifficulty Difficulty { get; set; }

        public int TurnCount { get; set; }

        public int BoardSize { get; set; }

        public virtual ICollection<GameParticipation> GameParticipation { get; set; }
    }
}