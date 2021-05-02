using System.Collections.Generic;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Facades.Interfaces;

namespace TicTacToe.BL.Facades
{
    public class StatsFacade : IStatsFacade
    {
        public List<LongGameListDTO> GetLongestGamesList()
        {
            throw new System.NotImplementedException();
        }

        public List<UserGameCountListDTO> GetMostGamesUserList()
        {
            throw new System.NotImplementedException();
        }

        public List<UserWinRateListDTO> GetBestWinRateUserList()
        {
            throw new System.NotImplementedException();
        }
    }
}