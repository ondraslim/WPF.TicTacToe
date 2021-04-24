using Microsoft.Extensions.DependencyInjection;
using TicTacToe.BL.Facades.Common;
using TicTacToe.BL.Services.Common;
using TicTacToe.BL.Services.Interfaces;

namespace TicTacToe.BL.Installers
{
    public class BusinessInstaller
    {

        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton<IDependencyInjectionService>(dependencyInjectionService);

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<BusinessInstaller>()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo<IFacade>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
            );
        }
    }
}