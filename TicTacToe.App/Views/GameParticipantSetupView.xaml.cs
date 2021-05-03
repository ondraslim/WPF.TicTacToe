using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Views
{
    public partial class GameParticipantSetupView
    {
        public GameParticipantSetupView(GameParticipationSetupViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
