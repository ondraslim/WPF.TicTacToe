using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services;
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

        private Task SignInAsync()
        {
            // TODO: check input data, show validation
            return userFacade.LoginAsync(LoginModel);
        }

        private Task SignUpAsync()
        {
            // TODO: check input data, show validation
            var result = navigationService.DisplayModal<SignUpViewModel>();

            if (result != true) return Task.CompletedTask;

            return userFacade.RegisterAsync(RegisterModel);
        }
    }
}