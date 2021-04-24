using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Infrastructure.Services.Common;

namespace TicTacToe.BL.Services
{
    public interface IAiGameplayService : ITransientService
    {
        // TODO: add argument BoardStateDTO?
        BoardPositionDTO MakeMove();
    }
}