using System.Threading.Tasks;
using TicTacToe.Core.ViewModels.Interface;

namespace TicTacToe.Core.Services.Interfaces
{
    public interface INavigationService : ISingletonService
    {
        Task NavigateTo<TViewModel>(TViewModel viewModel) where TViewModel : class, IViewModel;

        Task NavigateTo<TViewModel, TViewModelParameter>(TViewModel viewModel, TViewModelParameter viewModelParameter = default) 
            where TViewModel : class, IViewModel<TViewModelParameter>;
    }
}