using TicTacToe.BL.DTOs.User;

namespace TicTacToe.BL.Services
{
    public interface ICurrentUserProvider
    {
        UserDTO CurrentUser { get; }

        void SetCurrentUser(UserDTO currentUser);
    }
}