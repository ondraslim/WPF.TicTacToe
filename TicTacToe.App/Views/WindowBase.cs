using System;
using System.Windows;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Views
{
    public abstract class WindowBase : Window
    {
        protected WindowBase(IViewModel viewModel)
        {
            DataContext = viewModel;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (DataContext is IViewModel viewModel)
            {
                viewModel.OnInitialized();
            }
        }
    }
}