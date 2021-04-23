using System;
using System.Threading.Tasks;
using TicTacToe.App.Service.Interfaces;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Interface;

namespace TicTacToe.App.Service
{
    public class NavigationService : INavigationService
    {
        private readonly IMvvmLocatorService mvvmLocatorService;

        public NavigationService(IMvvmLocatorService mvvmLocatorService)
        {
            this.mvvmLocatorService = mvvmLocatorService;
        }

        public async Task PopAsync(bool animated = false)
        {
            //await navigation.PopAsync(animated);
        }

        public async Task PopToRootAsync(bool animated = false)
        {
            //await navigation.PopToRootAsync(animated);
        }

        public async Task PushAsync<TViewModel>(TViewModel viewModel = default, bool animated = false, bool clearHistory = false)
            where TViewModel : class, IViewModel
        {
            try
            {
                var view = mvvmLocatorService.ResolveView(viewModel);
                //await navigation.PushAsync(view, animated);
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------------------------------\n" + e.InnerException?.Message);
                throw;
            }
        }

        public async Task PushAsync<TViewModel, TViewModelParameter>(TViewModelParameter viewModelParameter = default, TViewModel viewModel = default, bool animated = default, bool clearHistory = default)
            where TViewModel : class, IViewModel<TViewModelParameter>
        {
            try
            {
                var view = mvvmLocatorService.ResolveView(viewModel, viewModelParameter);
                //await navigation.PushAsync(view, animated);
            }
            catch (Exception e)
            { 
                Console.WriteLine("------------------------------------------\n" + e.InnerException?.Message);
                throw;
            }
        }
    }
}
