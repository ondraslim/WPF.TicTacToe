using System;
using TicTacToe.Infrastructure.Entities;

namespace TicTacToe.Data.Models.Base
{
    public abstract class EntityBase : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}