using System.Windows.Controls;
using TicTacToe.BL.Services.Interfaces;
using TicTacToe.Core.ViewModels.Interface;

namespace TicTacToe.App.Service.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        Page ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel;

        Page ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}