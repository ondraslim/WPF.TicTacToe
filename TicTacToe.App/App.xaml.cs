using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using TicTacToe.App.Views;
using TicTacToe.App.Views.Gameplay;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        
        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");

            host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .ConfigureServices((context, services) => { ConfigureServices(context.Configuration, services); })
                .Build();
        }

        private static void ConfigureAppConfiguration(HostBuilderContext context, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(@"AppSettings.json", false, true);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<MainViewModel>();

            // TODO: register as transients
            services.AddSingleton<GameViewModel>();
            services.AddSingleton<GameView>();

            services.AddSingleton<GameSetupViewModel>();
            services.AddSingleton<GameSetupView>();

            services.AddSingleton<GameplayViewModel>();
            services.AddSingleton<GameplayView>();

            services.AddSingleton<StatisticsViewModel>();
            services.AddSingleton<StatisticsView>();


            //services.AddSingleton<IIngredientRepository, IngredientRepository>();
            //services.AddSingleton<IRecipeRepository, RecipeRepository>();

            //services.AddSingleton<IMessageDialogService, MessageDialogService>();
            //services.AddSingleton<IMediator, Mediator>();

            //services.AddSingleton<MainViewModel>();
            //services.AddSingleton<IIngredientListViewModel, IngredientListViewModel>();
            //services.AddFactory<IIngredientDetailViewModel, IngredientDetailViewModel>();
            //services.AddSingleton<IRecipeListViewModel, RecipeListViewModel>();
            //services.AddFactory<IRecipeDetailViewModel, RecipeDetailViewModel>();
            //services.AddFactory<IIngredientAmountDetailViewModel, IngredientAmountDetailViewModel>();

            //services.AddSingleton<IDbContextFactory<>>(provider => new SqlServerDbContextFactory(configuration.GetConnectionString("DefaultConnection")));

        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            //            var dbContextFactory = host.Services.GetRequiredService<IDbContextFactory>();

            //#if DEBUG
            //            await using (var dbx = dbContextFactory.CreateDbContext())
            //            {
            //                await dbx.Database.MigrateAsync();
            //            }
            //#endif

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
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
