using AutoMapper;
using TicTacToe.BL.DTOs.Game;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Mappings
{
    public class GameMapping : Profile, IMapping
    {
        public GameMapping()
        {
            CreateMap<Game, GameDTO>()
                .ForMember(d => d.GameParticipationList, o => o.MapFrom(e => e.GameParticipation));

            CreateMap<GameCreateDTO, Game>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.TurnCount, o => o.Ignore())
                .ForMember(e => e.GameParticipation, o => o.Ignore());
        }
    }
}