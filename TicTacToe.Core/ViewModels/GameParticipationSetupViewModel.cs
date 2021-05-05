using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
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
            IUserFacade userFacade)
            : base(viewModelParameter)
        {
            this.currentUserProvider = currentUserProvider;
            this.userFacade = userFacade;

            StartGameCommand = commandFactory.CreateAsyncCommand(StartGameAsync);
        }

        public override async Task OnInitialized()
        {
            if (!CanSelectOpponent)
            {
                ExternalOpponentName = "AI";
                return;
            }

            GameCreator = currentUserProvider.CurrentUser;
            var userList = await userFacade.GetUserListAsync();
            UserList = new ObservableCollection<UserDTO>(userList.Where(u => u.Id != GameCreator.Id));
        }

        public async Task StartGameAsync()
        {
            // check input
            // add game participants
            // prepare gameplayDTO
            // navigate to gameplayVM
        }
    }
}