using System;
using System.Windows.Controls;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.App.Views.Common
{
    public class ViewBase : UserControl
    {
        protected ViewBase(IViewModel viewModel)
        {
            DataContext = viewModel;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (DataContext is IViewModel viewModel)
            {
                // TODO: async OnInitialized??
                viewModel.OnInitialized().GetAwaiter().GetResult();
            }
        }
    }
}