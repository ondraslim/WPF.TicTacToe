using System.Windows.Controls;

namespace TicTacToe.App.Service.Interfaces
{
    public interface IMainContentViewUpdater
    {
        void SetMainContentView(UserControl contentView);
        
    }
}