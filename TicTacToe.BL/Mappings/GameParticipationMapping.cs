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
                .ForMember(d => d.Player, o => o.MapFrom(e => e.User));
        }
    }
}