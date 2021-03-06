using System;
using System.Linq;
using TicTacToe.BL.DTOs.Gameplay.Common;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class GameplayDTO : GameplayBaseDTO
    {
        public Guid GameId { get; set; }
        public GameType GameType { get; set; }

        public int TurnCount { get; set; } = 1;

        public BoardDTO Board { get; set; }

        public PlayerDTO PlayerOne { get; set; }
        public PlayerDTO PlayerTwo { get; set; }

        public Guid CurrentPlayerId { get; set; }

        public PlayerDTO CurrentPlayer => PlayerOne.Id == CurrentPlayerId ? PlayerOne : PlayerTwo;

        public bool IsActive { get; set; }

        public bool HasWinner => PlayerOne.IsWinner || PlayerTwo.IsWinner;

        public bool IsDraw => Board.Cells.All(c => !c.IsEmpty);

        public void TurnFinished()
        {
            CurrentPlayerId = CurrentPlayerId == PlayerOne.Id ? PlayerTwo.Id : PlayerOne.Id;
            TurnCount++;
        }
    }
}