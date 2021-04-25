using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Core.ViewModels.ControlViewModels;

namespace TicTacToe.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MainViewModel(NavigationViewModel navigationViewModel, INavigationService navigationService)
        {
            NavigationViewModel = navigationViewModel;
            this.navigationService = navigationService;
        }

        public NavigationViewModel NavigationViewModel { get; set; }

        public override void OnInitialized()
        {
            base.OnInitialized();
            navigationService.NavigateTo<HomeViewModel>();
        }
    }
}