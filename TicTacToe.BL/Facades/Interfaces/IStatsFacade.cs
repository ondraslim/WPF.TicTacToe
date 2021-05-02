using System.Collections.Generic;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IStatsFacade : IFacade
    {
        List<LongGameListDTO> GetLongestGamesList();
        List<UserGameCountListDTO> GetMostGamesUserList();
        List<UserWinRateListDTO> GetBestWinRateUserList();
    }
}