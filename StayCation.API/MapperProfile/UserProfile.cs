using AutoMapper;
using StayCation.API.DTOs.UserDTOs;
using StayCation.API.Models;

namespace StayCation.API.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>().ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId).ToList()));

            CreateMap<User, UserReturnDTO>().ReverseMap();
        }
    }
}
