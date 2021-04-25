using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.Common
{
    public interface IInstaller
    {
        void Install(IServiceCollection serviceCollection);
    }
}