using System.Windows;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.App.Views;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        private readonly IMvvmLocatorService mvvmLocatorService;
        private readonly IDependencyInjectionService dependencyInjectionService;

        private INavigationRoot navigationRoot;

        public NavigationService(IMvvmLocatorService mvvmLocatorService, IDependencyInjectionService dependencyInjectionService)
        {
            this.mvvmLocatorService = mvvmLocatorService;
            this.dependencyInjectionService = dependencyInjectionService;
        }

        // TODO: come up with clearer solution
        public void Initialize(INavigationRootBase navigationRoot)
        {
            this.navigationRoot = navigationRoot as INavigationRoot;
        }

        public void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel
        {
            var view = mvvmLocatorService.ResolveView(viewModel ?? dependencyInjectionService.Resolve<TViewModel>());
            
            navigationRoot.ContentPlaceholder.Children.Clear();
            navigationRoot.ContentPlaceholder.Children.Add(view);
        }

        public void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            var view = mvvmLocatorService.ResolveView(viewModel ?? dependencyInjectionService.Resolve<TViewModel>());

            navigationRoot.ContentPlaceholder.Children.Clear();
            navigationRoot.ContentPlaceholder.Children.Add(view);
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
