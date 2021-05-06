using Microsoft.EntityFrameworkCore;
using TicTacToe.Data.Models;

namespace TicTacToe.Data.EntityFramework
{
    public class TicTacToeDbContext : DbContext
    {
        public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options) 
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameParticipation> GameParticipation { get; set; }
    }
}