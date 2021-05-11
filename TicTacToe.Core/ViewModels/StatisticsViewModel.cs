using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class StatisticsViewModel : ViewModelBase
    {
        private readonly IStatsFacade statsFacade;

        public ICollection<UserGameCountListDTO> MostGamesList { get; set; }
        public ICollection<UserWinRateListDTO> UserWinRateList { get; set; }
        public ICollection<LongGameListDTO> LongGameList { get; set; }

        public StatisticsViewModel(IStatsFacade statsFacade)
        {
            this.statsFacade = statsFacade;
        }

        public override async Task OnLoadedAsync()
        {
            MostGamesList = await statsFacade.GetMostGamesUserListAsync();
            UserWinRateList = await statsFacade.GetBestWinRateUserListAsync();
            LongGameList = await statsFacade.GetLongestGamesListAsync();
            
            await base.OnLoadedAsync();
        }
    }
}