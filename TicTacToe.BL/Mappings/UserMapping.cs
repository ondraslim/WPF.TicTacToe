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

            CreateMap<UserCreateDTO, User>()
                .ForMember(u => u.Id, o => o.Ignore())
                .ForMember(u => u.PasswordHash, o => o.Ignore())
                .ForMember(u => u.PreferredLanguage, o => o.Ignore())
                .ForMember(u => u.GameParticipation, o => o.Ignore());
        }
    }
}