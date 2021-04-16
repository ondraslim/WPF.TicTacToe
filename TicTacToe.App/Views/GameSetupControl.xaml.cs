using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.Data.Entities.Enums;

namespace TicTacToe.App.Views
{
    /// <summary>
    /// Interaction logic for GameSetupControl.xaml
    /// </summary>
    public partial class GameSetupControl : UserControl
    {
        public event EventHandler CreateNewGameButtonClicked;
        public event EventHandler JoinGameButtonClicked;

        public GameCreateDTO Game = new();

        public GameSetupControl()
        {
            InitializeComponent();
        }

        private void BtnCreateNewGame_Click(object _, RoutedEventArgs e)
        {
            Game = new GameCreateDTO
            {
                BoardSize = (int) BoardSizeSlider.Value,
                Type = RadBtnGameModeLocal.IsChecked.GetValueOrDefault(true) ? GameType.Solo : GameType.Online
            };

            if (Game.Type == GameType.Online)
            {
                Game.AccessCode = Guid.NewGuid().ToString().Take(8).ToString();
            }

            CreateNewGameButtonClicked?.Invoke(this, e);
        }


        private void BtnJoinGame_Click(object _, RoutedEventArgs e)
            => JoinGameButtonClicked?.Invoke(this, e);
    }
}
