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
            gameplay.PlayerOne = new PlayerDTO
            {
                Id = firstPlayer?.Id ?? Guid.NewGuid(),
                Name = firstPlayer?.User?.Name ?? firstPlayer?.ExternalPlayerName,
                Sign = 'X',
            };

            var secondPlayer = gameParticipation.FirstOrDefault(p => !p.IsFirst);
            gameplay.PlayerTwo = new PlayerDTO
            {
                Id = secondPlayer?.Id ?? Guid.NewGuid(),
                Name = secondPlayer?.User?.Name ?? secondPlayer?.ExternalPlayerName,
                Sign = 'O'
            };

            gameplay.CurrentPlayerId = gameplay.PlayerOne.Id;

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
                    cells.Add(new BoardCellDTO { Row = row, Col = col });
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
            gameplay.IsActive = true;

            Reset();
            
            return gameplay;
        }
    }
}