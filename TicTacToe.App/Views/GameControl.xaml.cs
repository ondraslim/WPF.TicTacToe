using System.Windows;
using System.Windows.Controls;
using TicTacToe.App.Views.Game;

namespace TicTacToe.App.Views
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        
        public GameControl()
        {
            InitializeComponent();
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            RenderGamePages.Children.Clear();
            RenderGamePages.Children.Add(new GameSetupControl());
        }
    }
}
