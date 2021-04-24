using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            navigationService.NavigateTo<HomeViewModel>();
        }

        public IViewModel CurrentViewModel => navigationService.CurrentViewModel;
    }
}