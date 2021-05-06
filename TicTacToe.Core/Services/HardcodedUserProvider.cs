using System;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Services;

namespace TicTacToe.Core.Services
{
    public class HardcodedUserProvider : ICurrentUserProvider
    {
        private static Guid _mockId = Guid.NewGuid();

        public UserDTO CurrentUser { get; } = new() { Id = _mockId, Name = _mockId.ToString() };

        public void SetCurrentUser(UserDTO currentUser) { }
    }
}