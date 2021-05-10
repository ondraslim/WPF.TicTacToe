using System.ComponentModel;
using TicTacToe.BL.DTOs.User;

namespace TicTacToe.BL.Services
{
    public interface ICurrentUserProvider : INotifyPropertyChanged
    {
        UserDTO CurrentUser { get; }

        void SetCurrentUser(UserDTO currentUser);
        void Logout();
    }
}