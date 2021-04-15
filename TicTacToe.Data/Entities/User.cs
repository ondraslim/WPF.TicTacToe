using System.Collections.Generic;
using TicTacToe.Data.Entities.Base;

namespace TicTacToe.Data.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string PreferredLanguage { get; set; }

        public virtual ICollection<GameParticipation> GameParticipation { get; set; }
    }
}