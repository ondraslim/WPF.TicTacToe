using System.Windows.Input;

namespace TicTacToe.App.Views
{
    public abstract partial class MainWindow
    {
        protected MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

    }
}
