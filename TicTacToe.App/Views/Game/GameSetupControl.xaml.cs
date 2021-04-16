using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TicTacToe.App.Views.Game
{
    /// <summary>
    /// Interaction logic for GameSetupControl.xaml
    /// </summary>
    public partial class GameSetupControl : UserControl
    {

        public GameSetupControl()
        {
            InitializeComponent();

            var tttBoard = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent}\\Images\\ttt-board.png";
            TttBoard.Source = new BitmapImage(new Uri(tttBoard));
        }

        private void BtnCreateNewGame_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
