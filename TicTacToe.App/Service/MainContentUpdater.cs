using System.Windows.Controls;
using TicTacToe.App.Controls.Interfaces;
using TicTacToe.App.Service.Interfaces;

namespace TicTacToe.App.Service
{
    public class MainContentViewUpdater : IMainContentViewUpdater
    {
        private readonly IMainContentWrapper mainContentWrapper;

        public MainContentViewUpdater(IMainContentWrapper mainContentWrapper)
        {
            this.mainContentWrapper = mainContentWrapper;
        }

        public void SetMainContentView(UserControl contentView)
        {
            mainContentWrapper.SetContentView(contentView);
        }
    }
}