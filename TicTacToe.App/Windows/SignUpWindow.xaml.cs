using System.Windows;
using TicTacToe.Core.ViewModels;

namespace TicTacToe.App.Windows
{
    public partial class SignUpWindow
    {
        public SignUpWindow(SignUpViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
