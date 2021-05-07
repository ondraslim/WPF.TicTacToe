using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class GameplayView
    {
        public GameplayView(GameplayViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
