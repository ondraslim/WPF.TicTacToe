using System;
using System.Windows;
using System.Windows.Input;

namespace TicTacToe.App.Views
{
    public abstract partial class ViewBase : Window
    {
        protected ViewBase()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object _, RoutedEventArgs __)
        {
            LoadHomeControl();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //(DataContext as MainViewModel)?.OnInitialized(RenderPages);
        }


        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            LoadHomeControl();
        }

        private void BtnGame_Click(object _, RoutedEventArgs __)
        {
            //RenderPages.Children.Clear();
            //RenderPages.Children.Add(new GameView());
        }

        private void BtnStats_Click(object sender, RoutedEventArgs e)
        {
            //RenderPages.Children.Clear();
            //RenderPages.Children.Add(new StatisticsView());
        }

        private void LoadHomeControl()
        {
            //RenderPages.Children.Clear();
            //RenderPages.Children.Add(new HomeView());
        }

        private void BtnExit_Click(object _, RoutedEventArgs __)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

    }
}
