﻿using Microsoft.Extensions.DependencyInjection;
using TicTacToe.App.Service;
using TicTacToe.App.Views;
using TicTacToe.Infrastructure.Services.Common;

namespace TicTacToe.App.Installers
{
    public class AppInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<MainWindow>();
            serviceCollection.AddSingleton<INavigationRoot, MainWindow>();

            serviceCollection.AddTransient<HomeView>();
            serviceCollection.AddTransient<GameSetupView>();
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