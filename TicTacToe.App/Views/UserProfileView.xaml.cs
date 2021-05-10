using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class UserProfileView
    {
        public UserProfileView(UserProfileViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
