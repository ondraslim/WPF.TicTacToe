using TicTacToe.Common.IoC;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.Services.Interfaces
{
    public interface INavigationService : ISingletonService
    {
        void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel;

        void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default) 
            where TViewModel : class, IViewModel<TViewModelParameter>;

        void ExitApplication();
        bool? DisplayModal<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel;
    }
}