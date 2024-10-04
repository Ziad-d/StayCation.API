using AutoMapper;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleCreateDTO, Role>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
