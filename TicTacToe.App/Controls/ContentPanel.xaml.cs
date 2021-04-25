using System.Windows;
using System.Windows.Controls;
using TicTacToe.App.Controls.Interfaces;

namespace TicTacToe.App.Controls
{
    public partial class ContentWrapperPanel : IMainContentWrapper
    {
        public ContentWrapperPanel()
        {
            InitializeComponent();
        }

        public UIElement MainContentWrapper => this;

        public void SetContentView(UserControl content)
        {
            Children.Clear();
            Children.Add(content);
        }
    }
}
