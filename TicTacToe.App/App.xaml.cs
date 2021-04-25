using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using TicTacToe.App.Installers;
using TicTacToe.App.Views;
using TicTacToe.Common;
using TicTacToe.Core.Installers;
using TicTacToe.Data.EntityFramework.Factories;
using TicTacToe.Infrastructure.EntityFramework.Installers;
using TicTacToe.Infrastructure.Installers;
using TicTacToe.Infrastructure.Services;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        public IDependencyInjectionService DependencyInjectionService { get; }

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            DependencyInjectionService = new DependencyInjectionService();

            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"AppSettings.json", false, true);
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            new InfrastructureInstaller().Install(services, DependencyInjectionService);
            InstallerHelper.Install<EntityFrameworkInfrastructureInstaller>(services);
            InstallerHelper.Install<CoreInstaller>(services);
            InstallerHelper.Install<AppInstaller>(services);

            services.AddSingleton<IDbContextFactory>(_ => new SqlServerDbContextFactory(configuration.GetConnectionString("DefaultConnection")));

            DependencyInjectionService.Build(services);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var dbContextFactory = DependencyInjectionService.Resolve<IDbContextFactory>();

#if DEBUG
            await using (var dbx = dbContextFactory.CreateDbContext())
            {
                await dbx.Database.MigrateAsync();
            }
#endif

            var mainWindow = DependencyInjectionService.Resolve<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
