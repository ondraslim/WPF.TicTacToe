using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.App.Controls.Interfaces
{
    public interface IMainContentWrapper
    {
        UIElement MainContentWrapper { get; }

        void SetContentView(UserControl content);
        void SetValue(DependencyProperty dp, object value);
    }
}