using System.Collections.Generic;
using TicTacToe.Data.Models.Base;

namespace TicTacToe.Data.Models
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string PreferredLanguage { get; set; }

        public virtual ICollection<GameParticipation> GameParticipation { get; set; }
    }
}
