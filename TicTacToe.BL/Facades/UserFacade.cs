using System;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class UserFacade : IUserFacade
    {
        public UserDTO CreateUser(UserCreateDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUserInfo(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}