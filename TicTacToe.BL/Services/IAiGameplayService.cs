using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Common.IoC;

namespace TicTacToe.BL.Services
{
    public interface IAiGameplayService : ITransientService
    {
        // TODO: add argument BoardStateDTO?
        BoardPositionDTO MakeMove();
    }
}