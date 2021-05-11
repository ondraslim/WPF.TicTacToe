using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IStatsFacade : IFacade
    {
        Task<List<LongGameListDTO>> GetLongestGamesListAsync();
        Task<List<UserGameCountListDTO>> GetMostGamesUserListAsync();
        Task<List<UserWinRateListDTO>> GetBestWinRateUserListAsync();
    }
}