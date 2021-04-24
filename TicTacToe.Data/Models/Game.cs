using System.Collections.Generic;
using TicTacToe.Data.Models.Base;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.Data.Models
{
    public class Game : ModelBase
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