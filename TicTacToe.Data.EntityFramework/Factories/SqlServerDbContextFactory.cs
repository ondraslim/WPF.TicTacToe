using Microsoft.EntityFrameworkCore;


namespace TicTacToe.Data.EntityFramework.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory
    {
        private readonly string connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public TicTacToeDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TicTacToeDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new TicTacToeDbContext(optionsBuilder.Options);
        }
    }
}