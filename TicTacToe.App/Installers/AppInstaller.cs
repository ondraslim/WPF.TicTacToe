using Microsoft.Extensions.DependencyInjection;
using TicTacToe.App.Controls;
using TicTacToe.App.Controls.Interfaces;
using TicTacToe.App.Service;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.App.Views;
using TicTacToe.Common;
using TicTacToe.Common.IoC;

namespace TicTacToe.App.Installers
{
    public class AppInstaller : IInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainWindow>();

            serviceCollection.AddSingleton<IMainContentWrapper, ContentWrapperPanel>();
            serviceCollection.AddSingleton<IMainContentViewUpdater, MainContentViewUpdater>();

            serviceCollection.AddTransient<HomeView>();
            serviceCollection.AddTransient<GameSetupView>();
            serviceCollection.AddTransient<GameParticipationSetupView>();
            serviceCollection.AddTransient<GameplayView>();
            serviceCollection.AddTransient<StatisticsView>();

            serviceCollection.Scan(scan => scan
                .FromAssemblyOf<AppInstaller>()
                .AddClasses(classes => classes.AssignableTo<ISingletonService>())
                .AsSelfWithInterfaces()
                .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<ITransientService>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime());
        }
    }
}