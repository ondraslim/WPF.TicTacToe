using System;
using System.ComponentModel.DataAnnotations;
using TicTacToe.Infrastructure.Entities;

namespace TicTacToe.Data.Models.Base
{
    public abstract class EntityBase : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
    }
}