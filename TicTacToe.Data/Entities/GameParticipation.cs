using System;

namespace TicTacToe.Data.Entities
{
    public class GameParticipation
    {
        public Guid PlayerId { get; set; }
        public Guid GameId { get; set; }

        public bool IsWinner { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}