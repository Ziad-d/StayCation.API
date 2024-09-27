using AutoMapper;
using FoodApp.API.Models;
using StayCation.API.DTOs.UserDTOs;

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
