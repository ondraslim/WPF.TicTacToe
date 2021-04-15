using System;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class GameplayDTO
    {
        public BoardPositionDTO[,] BoardState { get; set; }

        public Guid PlayerOneId { get; set; }
        public Guid PlayerTwoId { get; set; }

        public Guid CurrentPlayerId { get; set; }

        public bool IsPlayersTurn(Guid playerId)
            => CurrentPlayerId == playerId;
    }
}