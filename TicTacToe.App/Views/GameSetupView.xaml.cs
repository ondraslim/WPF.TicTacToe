﻿using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class GameSetupView
    {
        public GameSetupView(GameSetupViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }

    }
}
