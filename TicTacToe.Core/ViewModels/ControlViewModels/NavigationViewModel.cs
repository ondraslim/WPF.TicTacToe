using System.ComponentModel;
using System.Windows.Input;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels.ControlViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly INavigationService navigationService;

        public bool IsGameEnabled => currentUserProvider.CurrentUser is not null;

        public ICommand GoToHomeCommand { get; set; }
        public ICommand GoToGameSetupCommand { get; set; }
        public ICommand GoToStatisticsCommand { get; set; }
        
        public ICommand ExitApplicationCommand { get; set; }

        public NavigationViewModel(
            ICommandFactory commandFactory, 
            INavigationService navigationService, 
            ICurrentUserProvider currentUserProvider)
        {
            this.navigationService = navigationService;
            this.currentUserProvider = currentUserProvider;

            currentUserProvider.PropertyChanged += UpdateGameEnabled;

            GoToHomeCommand = commandFactory.CreateCommand(NavigateToHome);
            GoToGameSetupCommand = commandFactory.CreateCommand(NavigateToGameSetup);
            GoToStatisticsCommand = commandFactory.CreateCommand(NavigateToStatistics);

            ExitApplicationCommand = commandFactory.CreateCommand(ExitApplication);
        }

        private void UpdateGameEnabled(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsGameEnabled));
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