using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TicTacToe.Data.EntityFramework.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
    {
        public TicTacToeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TicTacToeDbContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=TicTacToe;MultipleActiveResultSets=True;Integrated Security=True");

            return new TicTacToeDbContext(optionsBuilder.Options);
        }
    }
}