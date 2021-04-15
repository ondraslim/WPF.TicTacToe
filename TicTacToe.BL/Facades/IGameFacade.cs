using System.Collections.Generic;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades
{
    public interface IGameFacade : IFacade
    {
        GameDTO CreateGame(GameCreateDTO game);

        bool JoinGame(GameParticipationDTO game);

        void StartGameSolo(GameDTO game);

        // TODO: no idea what information will be needed for online game play
        void StartGameMultiplayer(GameDTO game);

        void SaveGameResult(GameDTO game);

        List<UserGameListDTO> GetLastGamesOfUser(int gameCountRequested);
    }
}