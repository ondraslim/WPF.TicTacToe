using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Core.ViewModels.ControlViewModels;

namespace TicTacToe.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MainViewModel(INavigationService navigationService, NavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
            this.navigationService = navigationService;

            navigationService.NavigateTo<HomeViewModel>();
        }

        public NavigationViewModel NavigationViewModel { get; set; }
        public IViewModel CurrentViewModel => navigationService.CurrentViewModel;
    }
}