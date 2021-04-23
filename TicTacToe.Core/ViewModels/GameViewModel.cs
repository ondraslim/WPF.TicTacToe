using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public GameViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        //public void OnInitialized(Panel view)
        //{
        //    navigationService.Initialize(view);
        //    navigationService.NavigateTo<GameSetupView>();
        //}
    }
}