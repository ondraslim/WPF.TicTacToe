using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.App.Views.Gameplay
{
    public partial class GameplayView
    {
        private bool firstPlayer = true;

        public GameplayView()
        {
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
