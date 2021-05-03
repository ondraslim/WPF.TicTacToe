using System.Threading.Tasks;

namespace TicTacToe.Core.ViewModels.Common
{
    public interface IViewModel
    {
        Task OnInitialized();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
    }
}