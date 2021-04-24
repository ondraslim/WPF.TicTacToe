﻿using System;
using System.Linq;
using System.Windows;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.Core.ViewModels;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.App.Views
{
    public partial class GameSetupView
    {
        public event EventHandler CreateNewGameButtonClicked;
        public event EventHandler JoinGameButtonClicked;

        public GameCreateDTO Game = new();

        public GameSetupView(GameSetupViewModel viewModel)
        {
            DataContext = viewModel;

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
