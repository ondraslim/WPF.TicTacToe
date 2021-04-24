using System.Windows.Input;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class MainWindow
    {
        // TODO: move DataContext = viewmodel to some base
        public MainWindow(MainViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

    }
}
