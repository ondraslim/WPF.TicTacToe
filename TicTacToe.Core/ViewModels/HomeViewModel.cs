using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IUserFacade userFacade;

        public string Name { get; set; }
        public string Password { get; set; }

        public ICommand SignInCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public HomeViewModel(
            ICommandFactory commandFactory,
            ICurrentUserProvider currentUserProvider,
            IUserFacade userFacade)
        {
            this.currentUserProvider = currentUserProvider;
            this.userFacade = userFacade;

            SignInCommand = commandFactory.CreateAsyncCommand(SignInAsync);
            SignUpCommand = commandFactory.CreateAsyncCommand(SignUpAsync);
        }

        private Task SignInAsync()
        {
            var user = new UserCreateDTO { Name = Name, Password = Password };
            return userFacade.LoginAsync(user);
        }

        private Task SignUpAsync()
        {
            var user = new UserCreateDTO { Name = Name, Password = Password };
            return userFacade.RegisterAsync(user);
        }
    }
}