using System;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IUserFacade : IFacade
    {
        public UserDTO CreateUser(UserCreateDTO user);

        public UserDTO GetUserInfo(Guid userId);
    }
}