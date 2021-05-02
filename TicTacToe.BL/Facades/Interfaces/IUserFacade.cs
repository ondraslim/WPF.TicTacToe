using System;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IUserFacade : IFacade
    {
        public Task<UserDTO> LoginAsync(UserCreateDTO user);

        public Task<UserDTO> RegisterAsync(UserCreateDTO user);

        public UserDTO GetUserInfo(Guid userId);
    }
}