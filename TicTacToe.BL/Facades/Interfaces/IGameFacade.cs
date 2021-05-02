using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IGameFacade : IFacade
    {
        Task<GameDTO> CreateGameAsync(GameCreateDTO game);

        Task StartGame(GameDTO game);

        void SaveGameResult(GameDTO game);

        List<UserGameListDTO> GetLastGamesOfUser(int gameCountRequested);
    }
}