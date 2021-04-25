using System.Windows;
using System.Windows.Controls;
using TicTacToe.App.Views.Gameplay;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class GameplayView
    {
        private bool firstPlayer = true;

        public GameplayView(GameplayViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

        private void CellClick(object sender, RoutedEventArgs e)
        {
            var cell = (sender as Button)?.DataContext as BoardCell;
            cell.Sign = firstPlayer ? "X" : "O";
            firstPlayer = !firstPlayer;
        }
    }
}
