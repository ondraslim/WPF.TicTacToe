using System.Threading.Tasks;
using System.Windows;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Views.Common
{
    public abstract class WindowBase : Window
    {
        protected WindowBase(IViewModel viewModel)
        {
            DataContext = viewModel;
            Loaded += async (s, e) => await OnLoadedAsync();
        }

        protected async Task OnLoadedAsync()
        {
            if (DataContext is IViewModel viewModel)
            {
                await viewModel.OnLoadedAsync();
            }
        }
    }
}