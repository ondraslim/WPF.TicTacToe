using Microsoft.Extensions.DependencyInjection;
using TicTacToe.Common.IoC;
using TicTacToe.Infrastructure.Services;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.Infrastructure.Installers
{
    public class InfrastructureInstaller
    {
        public void Install(IServiceCollection serviceCollection, IDependencyInjectionService dependencyInjectionService)
        {
            serviceCollection.AddSingleton<IDependencyInjectionService>(dependencyInjectionService);
            serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<InfrastructureInstaller>()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime()
            );
        }
    }
}