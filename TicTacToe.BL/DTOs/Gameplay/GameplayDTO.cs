using System;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class GameplayDTO
    {
        public Guid GameId { get; set; }
        public GameType GameType { get; set; }

        public BoardDTO Board { get; set; }

        public Guid PlayerOneId { get; set; }
        public Guid? PlayerTwoId { get; set; }

        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }

        public Guid CurrentPlayerId { get; set; }

        public bool IsPlayersTurn(Guid playerId)
            => CurrentPlayerId == playerId;
    }
}