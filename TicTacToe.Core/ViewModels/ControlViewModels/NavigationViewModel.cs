using System.Windows.Input;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels.ControlViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public ICommand GoToHomeCommand { get; set; }
        public ICommand GoToGameSetupCommand { get; set; }
        public ICommand GoToStatisticsCommand { get; set; }
        
        public ICommand ExitApplicationCommand { get; set; }


        public NavigationViewModel(ICommandFactory commandFactory, INavigationService navigationService)
        {
            this.navigationService = navigationService;

            GoToHomeCommand = commandFactory.CreateCommand(NavigateToHome);
            GoToGameSetupCommand = commandFactory.CreateCommand(NavigateToGameSetup);
            GoToStatisticsCommand = commandFactory.CreateCommand(NavigateToStatistics);

            ExitApplicationCommand = commandFactory.CreateCommand(ExitApplication);
        }

        public void NavigateToHome()
        {
            navigationService.NavigateTo<HomeViewModel>();
        }

        public void NavigateToGameSetup()
        {
            navigationService.NavigateTo<GameSetupViewModel>();
        }

        public void NavigateToStatistics()
        {
            navigationService.NavigateTo<StatisticsViewModel>();
        }

        public void ExitApplication()
        {
            navigationService.ExitApplication();
        }
    }
}