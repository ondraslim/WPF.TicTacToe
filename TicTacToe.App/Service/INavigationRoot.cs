using System.Windows.Controls;
using TicTacToe.Core.Services;

namespace TicTacToe.App.Service
{
    public interface INavigationRoot : INavigationRootBase
    {
        Panel ContentPlaceholder { get; }
        
        void Show();
    }
}