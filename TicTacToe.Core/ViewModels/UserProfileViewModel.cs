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
    public class UserProfileViewModel : ViewModelBase
    {
        private readonly IUserFacade userFacade;
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly INavigationService navigationService;

        public UserDTO CurrentUser => currentUserProvider.CurrentUser;

        public PasswordChangeDTO PasswordChangeModel { get; set; }

        public ICommand LogoutCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }

        public UserProfileViewModel(
            ICommandFactory commandFactory,
            ICurrentUserProvider currentUserProvider,
            IUserFacade userFacade,
            INavigationService navigationService)
        {
            this.currentUserProvider = currentUserProvider;
            this.userFacade = userFacade;
            this.navigationService = navigationService;

            InitPasswordChangeModel(currentUserProvider.CurrentUser);

            LogoutCommand = commandFactory.CreateCommand(Logout);
            ChangePasswordCommand = commandFactory.CreateAsyncCommand(ChangePasswordAsync);
        }

        private void InitPasswordChangeModel(UserDTO currentUser)
        {
            PasswordChangeModel = new PasswordChangeDTO { UserId = currentUser.Id };
        }

        private void Logout()
        {
            currentUserProvider.Logout();
            navigationService.NavigateTo<HomeViewModel>();
        }

        private async Task ChangePasswordAsync()
        {
            if (!PasswordChangeModel.IsValid()) return;

            await userFacade.ChangeUserPasswordAsync(PasswordChangeModel);

            InitPasswordChangeModel(currentUserProvider.CurrentUser);
        }

    }
}