using System.Collections.Generic;
using TicTacToe.Data.Entities.Base;
using TicTacToe.Data.Entities.Enums;

namespace TicTacToe.Data.Entities
{
    public class Game : EntityBase
    {
        public GameType Type { get; set; }
        
        // TODO: multiplayer might require more information
        public string AccessCode { get; set; }

        public int TurnCount { get; set; }

        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }

        public virtual ICollection<GameParticipation> GameParticipation { get; set; }
    }
}