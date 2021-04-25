using System.Windows.Controls;
using System.Windows.Input;
using TicTacToe.App.Controls.Interfaces;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class MainWindow
    {
        public MainWindow(MainViewModel viewModel, IMainContentWrapper mainContentWrapper)
            : base(viewModel)
        {
            InitializeComponent();

            mainContentWrapper.SetValue(Grid.ColumnProperty, 1);
            MainContentGrid.Children.Add(mainContentWrapper.MainContentWrapper);
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

    }
}
