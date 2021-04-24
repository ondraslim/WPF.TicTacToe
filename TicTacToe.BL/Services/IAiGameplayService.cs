using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Services.Interfaces;

namespace TicTacToe.BL.Services
{
    public interface IAiGameplayService : IService
    {
        // TODO: add argument BoardStateDTO?
        BoardPositionDTO MakeMove();
    }
}