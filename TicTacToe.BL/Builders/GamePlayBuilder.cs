using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.BL.Builders.Interfaces;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.Data.Models;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.BL.Builders
{
    public class GamePlayBuilder : IGamePlayBuilder
    {
        private GameplayDTO gameplay;

        public GamePlayBuilder CreateGameplay(Guid gameId, GameType type)
        {
            gameplay = new GameplayDTO { GameId = gameId, GameType = type };
            return this;
        }

        public GamePlayBuilder AddPlayers(ICollection<GameParticipation> gameParticipation)
        {
            var firstPlayer = gameParticipation.FirstOrDefault(p => p.IsFirst);
            gameplay.PlayerOneId = firstPlayer?.Id ?? Guid.NewGuid();
            gameplay.PlayerOneName = firstPlayer?.User?.Name ?? "AI";

            var secondPlayer = gameParticipation.FirstOrDefault(p => !p.IsFirst);
            gameplay.PlayerTwoId = secondPlayer?.Id ?? Guid.NewGuid();
            gameplay.PlayerTwoName = secondPlayer?.User?.Name ?? "AI";

            gameplay.CurrentPlayerId = gameplay.PlayerOneId;

            return this;
        }

        public GamePlayBuilder PrepareBoard(int boardSize)
        {
            var cells = CreateBoardCells(boardSize);
            gameplay.Board = new BoardDTO(boardSize, cells);

            return this;
        }

        private static List<BoardCellDTO> CreateBoardCells(int boardSize)
        {
            var cells = new List<BoardCellDTO>(boardSize * boardSize);

            for (var row = 0; row < boardSize; row++)
            for (var col = 0; col < boardSize; col++)
            {
                cells[row * boardSize + col] = new BoardCellDTO { X = row, Y = col };
            }

            return cells;
        }

        public void Reset()
        {
            gameplay = new GameplayDTO();
        }

        public GameplayDTO Build()
        {
            var gameplay = this.gameplay;
            Reset();
            return gameplay;
        }
    }
}