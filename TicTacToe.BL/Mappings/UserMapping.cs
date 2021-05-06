using AutoMapper;
using TicTacToe.BL.DTOs.User;
using TicTacToe.Data.Models;

namespace TicTacToe.BL.Mappings
{
    public class UserMapping : Profile, IMapping
    {
        public UserMapping()
        {
            CreateMap<User, UserDTO>();

            CreateMap<UserRegisterDTO, User>()
                .ForMember(e => e.Id, o => o.Ignore())
                .ForMember(e => e.PasswordHash, o => o.Ignore())
                .ForMember(e => e.PreferredLanguage, o => o.Ignore())
                .ForMember(e => e.GameParticipation, o => o.Ignore());
        }
    }
}