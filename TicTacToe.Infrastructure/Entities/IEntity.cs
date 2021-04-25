using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Infrastructure.Entities
{
    public interface IEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
