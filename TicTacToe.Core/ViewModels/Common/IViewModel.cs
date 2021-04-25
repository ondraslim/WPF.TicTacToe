namespace TicTacToe.Core.ViewModels.Common
{
    public interface IViewModel
    {
        void OnInitialized();
    }

    public interface IViewModel<TViewModelParameter> : IViewModel
    {
    }
}