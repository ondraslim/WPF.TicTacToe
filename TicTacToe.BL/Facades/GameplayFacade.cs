using System;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class GameplayFacade : IGameplayFacade
    {
        public bool IsWin { get; }
        public GameplayDTO InitializeGameSolo(GameDTO game)
        {
            throw new NotImplementedException();
        }

        public GameplayDTO InitializeGameMultiplayer(GameDTO game)
        {
            throw new NotImplementedException();
        }

        public void MakeMove(BoardCellDTO cell, Guid playerId)
        {
            throw new NotImplementedException();
        }
    }
}