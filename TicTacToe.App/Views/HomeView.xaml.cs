using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class HomeView
    {
        public HomeView(HomeViewModel viewModel)
        {
            DataContext = viewModel;

            InitializeComponent();
        }
    }
}
