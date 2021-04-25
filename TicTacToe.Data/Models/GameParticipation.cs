using System;
using TicTacToe.Data.Models.Base;

namespace TicTacToe.Data.Models
{
    public class GameParticipation : EntityBase
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }

        public bool IsWinner { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}