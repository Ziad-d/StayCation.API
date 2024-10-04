using AutoMapper;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Users.Register;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDTO, User>().ReverseMap();

            CreateMap<User, UserForTokenDTO>();
                //.ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId).ToList()));

            CreateMap<User, UserRegisterDTO>().ReverseMap();
        }
    }
}
