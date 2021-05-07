using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.Services.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IUserFacade userFacade;

        public UserLoginDTO LoginModel { get; set; } = new();
        public UserRegisterDTO RegisterModel { get; set; } = new();

        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public UserDTO CurrentUser => currentUserProvider.CurrentUser;

        public bool IsUserAuthenticated => CurrentUser is not null;
        public bool ShowLogin => !IsUserAuthenticated;

        public HomeViewModel(
            ICommandFactory commandFactory,
            IUserFacade userFacade,
            ICurrentUserProvider currentUserProvider)
        {
            this.userFacade = userFacade;
            this.currentUserProvider = currentUserProvider;

            SignInCommand = commandFactory.CreateAsyncCommand(SignInAsync);
            SignUpCommand = commandFactory.CreateAsyncCommand(SignUpAsync);
        }

        private async Task SignInAsync()
        {
            if (LoginModel.IsValid())
            {
                await userFacade.LoginAsync(LoginModel);
                NotifyAuthChanged();
            }
        }

        private async Task SignUpAsync()
        {
            if (RegisterModel.IsValid())
            {
                await userFacade.RegisterAsync(RegisterModel);
                NotifyAuthChanged();
            }
        }

        private void NotifyAuthChanged()
        {
            OnPropertyChanged(nameof(CurrentUser));
            OnPropertyChanged(nameof(IsUserAuthenticated));
            OnPropertyChanged(nameof(ShowLogin));
        }

    }
}