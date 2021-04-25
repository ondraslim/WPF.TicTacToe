using Microsoft.Extensions.DependencyInjection;
using TicTacToe.BL.Installers;
using TicTacToe.Core.Factories.Common;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.Services.Common;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.Core.Installers
{
    public class CoreInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            new BusinessInstaller().Install(serviceCollection, dependencyInjectionService);

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