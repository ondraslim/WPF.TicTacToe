using System.Windows;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        // TODO: use this instead of fixed binds in App.xaml
        private readonly IMvvmLocatorService mvvmLocatorService;

        public IViewModel CurrentViewModel { get; private set; }

        public NavigationService(IMvvmLocatorService mvvmLocatorService)
        {
            this.mvvmLocatorService = mvvmLocatorService;
        }

        public void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel
        {
            CurrentViewModel = viewModel;
        }

        public void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            CurrentViewModel = viewModel;
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
