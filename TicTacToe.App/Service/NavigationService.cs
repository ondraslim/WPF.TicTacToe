using System.Threading.Tasks;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Interface;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        private readonly System.Windows.Navigation.NavigationService navigationService;
        private readonly IMvvmLocatorService mvvmLocatorService;

        public NavigationService(IMvvmLocatorService mvvmLocatorService, System.Windows.Navigation.NavigationService navigationService)
        {
            this.mvvmLocatorService = mvvmLocatorService;
            this.navigationService = navigationService;
        }

        public async Task NavigateTo<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel
        {
            var view = mvvmLocatorService.ResolveView(viewModel);
            navigationService.Navigate(view);
        }

        public async Task NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel, TViewModelParameter viewModelParameter = default) 
            where TViewModel : class, IViewModel<TViewModelParameter>
        {

            var view = mvvmLocatorService.ResolveView(viewModel, viewModelParameter);
            navigationService.Navigate(view);
        }

    }
}
