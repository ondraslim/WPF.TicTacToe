using System.Collections.Generic;
using TicTacToe.BL.DTOs.Stats;
using TicTacToe.Core.ViewModels;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.App.Views
{
    public partial class StatisticsView
    {
        public ICollection<UserGameCountListDTO> GameCountList { get; set; }
        public ICollection<UserWinRateListDTO> UserWinRateList { get; set; }
        public ICollection<LongGameListDTO> LongGameList { get; set; }

        public StatisticsView()
        {
            InitializeComponent();

            InitializeGameCountList();
            InitializeUserWinRateList();
            InitializeLongGameList();
        }

        public StatisticsView(StatisticsViewModel statisticsViewModel)
        {
            InitializeComponent();

            DataContext = statisticsViewModel;

            InitializeGameCountList();
            InitializeUserWinRateList();
            InitializeLongGameList();
        }

        private void InitializeGameCountList()
        {
            GameCountList = new List<UserGameCountListDTO>
            {
                new()
                {
                    UserName = "Me",
                    GameCount = 123
                },
                new()
                {
                    UserName = "Hubert",
                    GameCount = 101
                },
                new()
                {
                    UserName = "Huberta",
                    GameCount = 44
                },
            };

            MostGamesListView.ItemsSource = GameCountList;
        }

        private void InitializeUserWinRateList()
        {
            UserWinRateList = new List<UserWinRateListDTO>
            {
                new()
                {
                    UserName = "Me",
                    GamesPlayedCount = 100,
                    WinRate = 80
                },
                new()
                {
                    UserName = "Hubert",
                    GamesPlayedCount = 50,
                    WinRate = 60
                },
                new()
                {
                    UserName = "Huberta",
                    GamesPlayedCount = 40,
                    WinRate = 60
                }
            };

            BestWinRateListView.ItemsSource = UserWinRateList;
        }

        private void InitializeLongGameList()
        {
            LongGameList = new List<LongGameListDTO>
            {
                new()
                {
                    Opponent = "Opponent1",
                    TurnCount = 42,
                    Type = GameType.Online
                },
                new()
                {
                    Opponent = "Opponent2",
                    TurnCount = 39,
                    Type = GameType.Online
                },
                new()
                {
                    Opponent = "AI",
                    TurnCount = 32,
                    Type = GameType.Solo
                }
            };

            LongestGamesListView.ItemsSource = LongGameList;
        }
    }
}