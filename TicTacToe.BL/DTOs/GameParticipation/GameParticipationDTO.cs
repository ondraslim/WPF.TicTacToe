using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.User;

namespace TicTacToe.BL.DTOs.GameParticipation
{
    public class GameParticipationDTO
    {
        public bool IsWinner { get; set; }

        public UserDTO Player { get; set; }
        public GameDTO Game { get; set; }
    }
}