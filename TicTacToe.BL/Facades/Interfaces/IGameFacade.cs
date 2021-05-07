using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.BL.DTOs.Gameplay;
using TicTacToe.BL.Facades.Common;

namespace TicTacToe.BL.Facades.Interfaces
{
    public interface IGameFacade : IFacade
    {
        Task<GameDTO> CreateGameAsync(GameCreateDTO game);
        Task AddGameParticipationAsync(IList<GameParticipationSetupDTO> gameParticipationList);
        Task<GameplayDTO> StartGameAsync(Guid gameId);
        Task SaveGameResultAsync(GameResultDTO result);
    }
}