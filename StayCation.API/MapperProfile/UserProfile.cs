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
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
