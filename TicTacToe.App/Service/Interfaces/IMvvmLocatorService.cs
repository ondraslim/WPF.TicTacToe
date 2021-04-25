using System.Windows.Controls;
using TicTacToe.Common.IoC;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Service.Interfaces
{
    public interface IMvvmLocatorService : ISingletonService
    {
        UserControl ResolveView<TViewModel>(TViewModel viewModel = default)
            where TViewModel : class, IViewModel;

        UserControl ResolveView<TViewModel, TViewModelParameter>(TViewModel viewModel = default, TViewModelParameter viewModelParameter = default)
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}