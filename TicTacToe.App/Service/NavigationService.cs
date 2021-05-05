using System;
using System.Windows;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Infrastructure.Services.Interfaces;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        private readonly IMvvmLocatorService mvvmLocatorService;
        private readonly IDependencyInjectionService dependencyInjectionService;
        private readonly IMainContentViewUpdater mainContentViewUpdater;

        public NavigationService(
            IMvvmLocatorService mvvmLocatorService,
            IDependencyInjectionService dependencyInjectionService, 
            IMainContentViewUpdater mainContentViewUpdater)
        {
            this.mvvmLocatorService = mvvmLocatorService;
            this.dependencyInjectionService = dependencyInjectionService;
            this.mainContentViewUpdater = mainContentViewUpdater;
        }
        
        public void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel
        {
            var view = mvvmLocatorService.ResolveView(viewModel ?? dependencyInjectionService.Resolve<TViewModel>());
            mainContentViewUpdater.SetMainContentView(view);
        }

        public void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            try
            {
                var view = mvvmLocatorService.ResolveView(viewModel, viewModelParameter);
                mainContentViewUpdater.SetMainContentView(view);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

    }
}
