using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.App.Views.Gameplay
{
    /// <summary>
    /// Interaction logic for GameplayView.xaml
    /// </summary>
    public partial class GameplayView : UserControl
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
