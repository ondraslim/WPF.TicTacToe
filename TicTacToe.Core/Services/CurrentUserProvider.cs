using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Services;

namespace TicTacToe.Core.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public UserDTO CurrentUser { get; private set; }
        public void SetCurrentUser(UserDTO currentUser) => CurrentUser = currentUser;
    }
}