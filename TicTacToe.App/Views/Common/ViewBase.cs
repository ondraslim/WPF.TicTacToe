using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Views.Common
{
    public class ViewBase : UserControl
    {
        protected ViewBase(IViewModel viewModel)
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