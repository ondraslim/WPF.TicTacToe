using System;
using System.Collections.Generic;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Data.Models;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.Builders.Interfaces
{
    public interface IGamePlayBuilder : IBuilder
    {
        GamePlayBuilder CreateGameplay(Guid gameId, GameType type);
        GamePlayBuilder AddPlayers(ICollection<GameParticipation> GameParticipation);
        GamePlayBuilder PrepareBoard(int boardSize);
        GameplayDTO Build();
    }
}