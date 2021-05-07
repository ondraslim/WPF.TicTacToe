using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.BL.Annotations;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Services;

namespace TicTacToe.Core.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        public UserDTO CurrentUser { get; private set; }

        public void SetCurrentUser(UserDTO currentUser)
        {
            CurrentUser = currentUser;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}