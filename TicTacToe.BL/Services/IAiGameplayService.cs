using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Services.Common;

namespace TicTacToe.BL.Services
{
    public interface IAiGameplayService : IService
    {
        // TODO: add argument BoardStateDTO?
        BoardPositionDTO MakeMove();
    }
}