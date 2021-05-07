using System.Threading.Tasks;
using TicTacToe.Core.Services.Interfaces;
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

        public override async Task OnLoadedAsync()
        {
            await base.OnLoadedAsync();
            navigationService.NavigateTo<HomeViewModel>();
        }
    }
}