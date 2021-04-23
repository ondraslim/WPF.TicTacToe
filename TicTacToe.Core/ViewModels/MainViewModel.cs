using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public void OnInitialized(Panel view)
        {
            navigationService.Initialize(view);
            navigationService.NavigateTo<HomeView>();
        }
        
    }
}