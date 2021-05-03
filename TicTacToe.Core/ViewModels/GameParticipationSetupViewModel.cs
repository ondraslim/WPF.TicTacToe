using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.User;
using TicTacToe.BL.Facades.Interfaces;
using TicTacToe.BL.Services;
using TicTacToe.Core.Factories;
using TicTacToe.Core.ViewModels.Common;

namespace TicTacToe.Core.ViewModels
{
    public class GameParticipationSetupViewModel : ViewModelBase<GameDTO>
    {
        private readonly ICurrentUserProvider currentUserProvider;
        private readonly IUserFacade userFacade;

        public UserDTO GameCreator { get; set; }

        public List<UserDTO> UserList { get; set; }

        public Guid? OpponentId { get; set; }
        public string OpponentName { get; set; }

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
        }

        public override async Task OnInitialized()
        {
            GameCreator = currentUserProvider.CurrentUser;
            UserList = await userFacade.GetUserListAsync();
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