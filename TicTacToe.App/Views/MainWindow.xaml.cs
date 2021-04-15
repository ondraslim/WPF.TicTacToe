using System.Windows;
using System.Windows.Input;

namespace TicTacToe.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object _, RoutedEventArgs __)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());
        }

        private void BtnExit_Click(object _, RoutedEventArgs __)
        {
            Application.Current.Shutdown();
        }

        private void MainWindow_MouseDown(object _, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }

        private void BtnGame_Click(object _, RoutedEventArgs __)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new GameControl());
        }

        private void BtnStats_Click(object sender, RoutedEventArgs e)
        {
            // TODO: implement
        }
    }
}
