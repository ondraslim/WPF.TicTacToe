using System;
using TicTacToe.BL.DTOs.Gameplay.Common;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class PlayerDTO : GameplayBaseDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public char Sign { get; init; }
    }
}