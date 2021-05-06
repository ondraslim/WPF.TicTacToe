using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicTacToe.Data.Models.Base;

namespace TicTacToe.Data.Models
{
    public class GameParticipation : EntityBase
    {
        [MaxLength(200)]
        public string ExternalPlayerName { get; set; }

        public bool IsFirst { get; set; }
        public bool IsWinner { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }

        [ForeignKey(nameof(Game))]
        public Guid GameId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}