using System;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.App.Views.Gameplay;
using TicTacToe.BL.DTOs.Game;

namespace TicTacToe.App.Views
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        private GameSetupControl gameSetupControl;
        private GameplayControl gameplayControl;

        public GameControl()
        {
            InitializeComponent();
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGameSetup(sender, e);
        }

        private void LoadGameSetup(object sender, EventArgs e)
        {
            gameSetupControl = new GameSetupControl();
            gameSetupControl.CreateNewGameButtonClicked += CreateNewGame_Clicked;
            gameSetupControl.JoinGameButtonClicked += JoinGame_Clicked;

            LoadControl(gameSetupControl);
        }

        private void CreateNewGame_Clicked(object sender, EventArgs e)
        {
            LoadGameplay(gameSetupControl.Game);
        }

        private void LoadGameplay(GameCreateDTO game)
        {
            gameplayControl = new GameplayControl();
            LoadControl(gameplayControl);
        }

        private void JoinGame_Clicked(object sender, EventArgs e)
        {
            // TODO: show dialog with code entry
        }

        private void LoadControl(UIElement control)
        {
            RenderGamePages.Children.Clear();
            RenderGamePages.Children.Add(control);
        }
    }
}
