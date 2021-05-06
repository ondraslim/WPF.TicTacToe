using System.Threading.Tasks;

namespace TicTacToe.Core.ViewModels.Common
{
    public interface IViewModel
    {
        Task OnLoadedAsync();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
    }
}