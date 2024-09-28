using AutoMapper;
using StayCation.API.DTOs.RoleDTOs;
using StayCation.API.Models;

namespace StayCation.API.MapperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleCreateDTO, Role>();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
