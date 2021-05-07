using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Common.IoC;

namespace TicTacToe.Core.Services.Interfaces
{
    public interface IGameplayService : ISingletonService
    {
        bool CheckIsWin(BoardDTO board, BoardCellDTO selectedCell);
    }
}