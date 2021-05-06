using System;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IGameplayFacade : IFacade
    {
        // private GameplayDTO
        bool IsWin { get; }

        GameplayDTO InitializeGameSolo(GameDTO game);
        
        GameplayDTO InitializeGameMultiplayer(GameDTO game);

        void MakeMove(BoardCellDTO cell, Guid playerId);

    }
}