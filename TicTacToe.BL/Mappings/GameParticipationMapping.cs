using AutoMapper;
using TicTacToe.BL.DTOs.GameParticipation;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Mappings
{
    public class GameParticipationMapping : Profile, IMapping
    {
        public GameParticipationMapping()
        {
            CreateMap<GameParticipation, GameParticipationDTO>()
                .ForMember(d => d.User, o => o.MapFrom(e => e.User));

            CreateMap<GameParticipationSetupDTO, GameParticipation>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.IsWinner, o => o.Ignore())
                .ForMember(e => e.User, o => o.Ignore())
                .ForMember(e => e.Game, o => o.Ignore());
        }
    }
}