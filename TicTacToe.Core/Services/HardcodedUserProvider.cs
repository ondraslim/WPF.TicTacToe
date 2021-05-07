using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TicTacToe.BL.Annotations;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Services;

namespace TicTacToe.Core.Services
{
    public class HardcodedUserProvider : ICurrentUserProvider
    {
        private static Guid _mockId = Guid.NewGuid();

        public UserDTO CurrentUser { get; } = new() { Id = _mockId, Name = _mockId.ToString() };

        public void SetCurrentUser(UserDTO currentUser) { }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}