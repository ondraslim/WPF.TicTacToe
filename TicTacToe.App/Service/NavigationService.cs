using System.Windows;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.BL.Services.Interfaces;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        // TODO: use this instead of fixed binds in App.xaml
        private readonly IMvvmLocatorService mvvmLocatorService;

        private readonly IDependencyInjectionService dependencyInjectionService;

        public IViewModel CurrentViewModel { get; private set; }

        public NavigationService(IMvvmLocatorService mvvmLocatorService, IDependencyInjectionService dependencyInjectionService)
        {
            this.mvvmLocatorService = mvvmLocatorService;
            this.dependencyInjectionService = dependencyInjectionService;
        }

        public void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel
        {
            CurrentViewModel = viewModel ?? dependencyInjectionService.Resolve<TViewModel>();
        }

        public void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            CurrentViewModel = viewModel ?? dependencyInjectionService.Resolve<TViewModel>();
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
