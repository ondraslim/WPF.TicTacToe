using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TicTacToe.Data.Models.Base;

namespace TicTacToe.Data.Models
{
    public class User : EntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public string PasswordHash { get; set; }
        
        public string PreferredLanguage { get; set; }

        public virtual ICollection<GameParticipation> GameParticipation { get; set; }
    }
}
