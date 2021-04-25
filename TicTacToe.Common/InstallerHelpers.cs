using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.Common
{
    public static class InstallerHelper
    {
        public static void Install<T>(IServiceCollection serviceCollection)
            where T : IInstaller, new()
        {
            new T().Install(serviceCollection);
        }
    }
}
