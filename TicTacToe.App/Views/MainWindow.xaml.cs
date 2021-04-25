using System;
using System.Windows.Controls;
using System.Windows.Input;
using TicTacToe.App.Service;
using TicTacToe.Core.Services;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class MainWindow : INavigationRoot
    {
        private readonly INavigationService navigationService;

        public MainWindow(MainViewModel viewModel, INavigationService navigationService) : base(viewModel)
        {
            this.navigationService = navigationService;

            InitializeComponent();
        }

        public Panel ContentPlaceholder => Content;

        protected override void OnInitialized(EventArgs e)
        {
            navigationService.Initialize(this);

            base.OnInitialized(e);
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

    }
}
