using TicTacToe.BL.Services.Common;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.Services
{
    public interface INavigationService : ISingletonService
    {
        IViewModel CurrentViewModel { get; }

        void NavigateTo<TViewModel>(TViewModel viewModel = default) where TViewModel : class, IViewModel;

        void NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default) 
            where TViewModel : class, IViewModel<TViewModelParameter>;

        void ExitApplication();
    }
}