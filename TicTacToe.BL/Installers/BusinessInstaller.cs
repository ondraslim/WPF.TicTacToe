using Microsoft.Extensions.DependencyInjection;
using TicTacToe.BL.Facades.Common;
using TicTacToe.Infrastructure.EntityFramework.Installers;
using TicTacToe.Infrastructure.Installers;
using TicTacToe.Infrastructure.Services.Common;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.BL.Installers
{
    public class BusinessInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            new InfrastructureInstaller().Install(serviceCollection, dependencyInjectionService);
            new EntityFrameworkInstaller().Install(serviceCollection);

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