using System;

namespace TicTacToe.BL.DTOs.Gameplay
{
    public class PlayerDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Sign { get; init; }
    }
}