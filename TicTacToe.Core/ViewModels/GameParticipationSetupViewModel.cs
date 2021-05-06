using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.ViewModels.Common;
using TicTacToe.Data.Models.Enums;

namespace TicTacToe.Core.ViewModels
{
    public class GameParticipationSetupViewModel : ViewModelBase<GameDTO>
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IUserFacade userFacade;
        private readonly IGameFacade gameFacade;

        private bool creatorStarts = true;
        private bool opponentStarts = false;

        public GameDTO Game
        {
            get => ViewModelParameter;
            set => ViewModelParameter = value;
        }

        public UserDTO GameCreator { get; set; }

        public ObservableCollection<UserDTO> UserList { get; set; }

        public UserDTO SelectedOpponent { get; set; }
        public string ExternalOpponentName { get; set; }

        public bool CanSelectOpponent => Game.Type == GameType.Multiplayer;

        public bool CreatorStarts
        {
            get => creatorStarts;
            set
            {
                creatorStarts = value;
                opponentStarts = !value;
                OnPropertyChanged(nameof(OpponentStarts));
            }
        }

        public bool OpponentStarts
        {
            get => opponentStarts;
            set
            {
                opponentStarts = value;
                creatorStarts = !value;
                OnPropertyChanged(nameof(CreatorStarts));
            }
        }

        public ICommand StartGameCommand { get; set; }

        public GameParticipationSetupViewModel(
            GameDTO viewModelParameter,
            ICommandFactory commandFactory,
            ICurrentUserProvider currentUserProvider,
            IUserFacade userFacade, 
            IGameFacade gameFacade)
            : base(viewModelParameter)
        {
            this.currentUserProvider = currentUserProvider;
            this.userFacade = userFacade;
            this.gameFacade = gameFacade;

            StartGameCommand = commandFactory.CreateAsyncCommand(StartGameAsync);
        }

        public override async Task OnLoadedAsync()
        {
            GameCreator = currentUserProvider.CurrentUser;

            if (!CanSelectOpponent)
            {
                ExternalOpponentName = "AI";
                return;
            }

            var userList = await userFacade.GetUserListAsync();
            UserList = new ObservableCollection<UserDTO>(userList.Where(u => u.Id != GameCreator.Id));
        }

        public async Task StartGameAsync()
        {
            // TODO: check input
            var gameParticipationList = PrepareGameParticipationList();
            await gameFacade.AddGameParticipationAsync(gameParticipationList);

            var gameplay = gameFacade.StartGameAsync(Game.Id);
            // navigate to gameplayVM
        }

        private List<GameParticipationSetupDTO> PrepareGameParticipationList()
        {
            var gameParticipation = new List<GameParticipationSetupDTO>
            {
                new()
                {
                    GameId = Game.Id,
                    UserId = GameCreator.Id,
                    IsFirst = CreatorStarts
                },
                new()
                {
                    GameId = Game.Id,
                    UserId = SelectedOpponent?.Id,
                    IsFirst = OpponentStarts,
                    ExternalPlayerName = ExternalOpponentName,
                }
            };

            return gameParticipation;
        }
    }
}