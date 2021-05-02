using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.Facades.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class GameFacade : IGameFacade
    {
        public Task<GameDTO> CreateGameAsync(GameCreateDTO game)
        {
            throw new System.NotImplementedException();
        }

        public Task StartGame(GameDTO game)
        {
            throw new System.NotImplementedException();
        }

        public void SaveGameResult(GameDTO game)
        {
            throw new System.NotImplementedException();
        }

        public List<UserGameListDTO> GetLastGamesOfUser(int gameCountRequested)
        {
            throw new System.NotImplementedException();
        }
    }
}