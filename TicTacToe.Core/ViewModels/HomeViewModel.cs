using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IUserFacade userFacade;
        private readonly INavigationService navigationService;

        public UserLoginDTO LoginModel { get; set; } = new();
        public UserRegisterDTO RegisterModel { get; set; } = new();

        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public HomeViewModel(
            ICommandFactory commandFactory,
            IUserFacade userFacade,
            INavigationService navigationService)
        {
            this.userFacade = userFacade;
            this.navigationService = navigationService;

            SignInCommand = commandFactory.CreateAsyncCommand(SignInAsync);
            SignUpCommand = commandFactory.CreateAsyncCommand(SignUpAsync);
        }

        private async Task SignInAsync()
        {
            if (LoginModel.IsValid())
            {
                await userFacade.LoginAsync(LoginModel);
            }
        }

        private async Task SignUpAsync()
        {
            if (RegisterModel.IsValid())
            {
                await userFacade.RegisterAsync(RegisterModel);
            }
        }
    }
}