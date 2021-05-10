using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IUserFacade : IFacade
    {
        Task<UserDTO> LoginAsync(UserLoginDTO user);

        Task<UserDTO> RegisterAsync(UserRegisterDTO user);

        Task<List<UserDTO>> GetUserListAsync();
        Task ChangeUserPasswordAsync(PasswordChangeDTO passwordChange);
    }
}