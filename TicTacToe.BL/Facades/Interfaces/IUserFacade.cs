using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IUserFacade : IFacade
    {
        Task<UserDTO> LoginAsync(UserCreateDTO user);

        Task<UserDTO> RegisterAsync(UserCreateDTO user);

        Task<List<UserDTO>> GetUserListAsync();
    }
}