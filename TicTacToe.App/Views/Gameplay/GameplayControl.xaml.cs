using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.App.Views.Gameplay
{
    /// <summary>
    /// Interaction logic for GameplayControl.xaml
    /// </summary>
    public partial class GameplayControl : UserControl
    {
        private bool firstPlayer = true;

        public GameplayControl()
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
