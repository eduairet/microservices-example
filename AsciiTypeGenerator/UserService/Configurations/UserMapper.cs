using AutoMapper;
using UserService.Entities;
using UserService.Models.User;

namespace UserService.Configurations;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserRegister, User>()
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => UserRoles.User))
            .ReverseMap();
    }
}