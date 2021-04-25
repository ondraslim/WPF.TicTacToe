using Microsoft.Extensions.DependencyInjection;
using TicTacToe.BL.Facades.Common;
using TicTacToe.Common;
using TicTacToe.Common.IoC;

namespace TicTacToe.BL.Installers
{
    public class BusinessInstaller : IInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
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