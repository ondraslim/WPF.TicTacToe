using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.User;

namespace TicTacToe.BL.DTOs.GameParticipation
{
    public class GameParticipationDTO
    {
        public UserDTO User { get; set; }
        public string ExternalPlayerName { get; set; }

        public GameDTO Game { get; set; }
    }
}