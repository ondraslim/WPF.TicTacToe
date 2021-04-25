namespace TicTacToe.Data.EntityFramework.Factories
{
    public interface IDbContextFactory
    {
        TicTacToeDbContext CreateDbContext();
    }
}