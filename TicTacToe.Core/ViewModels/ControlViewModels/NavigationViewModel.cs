using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using TicTacToe.BL.DTOs.User;
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
        private readonly ILocalizationService localizationService;

        public bool IsGameEnabled => currentUserProvider.CurrentUser is not null;
        public UserDTO CurrentUser => currentUserProvider.CurrentUser;

        public CultureInfo SelectedCulture
        {
            get => localizationService.CurrentCultureInfo; 
            set => localizationService.SetCulture(value);
        }

        public IList<CultureInfo> SupportedLanguages { get; set; }

        public ICommand GoToUserProfileCommand { get; set; }
        public ICommand GoToHomeCommand { get; set; }
        public ICommand GoToGameSetupCommand { get; set; }
        public ICommand GoToStatisticsCommand { get; set; }
        
        public ICommand ExitApplicationCommand { get; set; }

        public NavigationViewModel(
            ICommandFactory commandFactory, 
            INavigationService navigationService, 
            ICurrentUserProvider currentUserProvider, 
            ILocalizationService localizationService)
        {
            this.navigationService = navigationService;
            this.currentUserProvider = currentUserProvider;
            this.localizationService = localizationService;

            SupportedLanguages = localizationService.SupportedLanguages;

            currentUserProvider.PropertyChanged += UserChanged;

            GoToUserProfileCommand = commandFactory.CreateCommand(NavigateToUserProfile);
            GoToHomeCommand = commandFactory.CreateCommand(NavigateToHome);
            GoToGameSetupCommand = commandFactory.CreateCommand(NavigateToGameSetup);
            GoToStatisticsCommand = commandFactory.CreateCommand(NavigateToStatistics);

            ExitApplicationCommand = commandFactory.CreateCommand(ExitApplication);
        }

        private void UserChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(IsGameEnabled));
            OnPropertyChanged(nameof(CurrentUser));
        }

        public void NavigateToUserProfile()
        {
            navigationService.NavigateTo<UserProfileViewModel>();
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