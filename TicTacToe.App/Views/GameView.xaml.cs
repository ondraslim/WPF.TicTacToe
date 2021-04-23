using System;
using System.Windows;
using TicTacToe.App.Views.Gameplay;
using TicTacToe.BL.DTOs.Game;

namespace TicTacToe.App.Views
{
    public partial class GameView
    {
        private GameSetupView gameSetupView;
        private GameplayView gameplayView;

        public GameView()
        {
            InitializeComponent();
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGameSetup(sender, e);
        }

        private void LoadGameSetup(object sender, EventArgs e)
        {
            gameSetupView = new GameSetupView();
            gameSetupView.CreateNewGameButtonClicked += CreateNewGame_Clicked;
            gameSetupView.JoinGameButtonClicked += JoinGame_Clicked;

            LoadControl(gameSetupView);
        }

        private void CreateNewGame_Clicked(object sender, EventArgs e)
        {
            LoadGameplay(gameSetupView.Game);
        }

        private void LoadGameplay(GameCreateDTO game)
        {
            gameplayView = new GameplayView();
            LoadControl(gameplayView);
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
