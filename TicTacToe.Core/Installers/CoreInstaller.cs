using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Core.Factories.Common;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.Services.Common;

namespace TicTacToe.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<CoreInstaller>()
                .AddClasses(classes => classes.AssignableTo<IFactory>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IViewModel>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
            );
        }

    }
}