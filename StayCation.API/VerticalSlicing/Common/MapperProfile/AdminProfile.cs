using AutoMapper;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Admin.AssignFeaturesToRole;
using StayCation.API.VerticalSlicing.Features.Admin.AssignRolesToUser;
using StayCation.API.VerticalSlicing.Features.Admin.CreateRole;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<RoleCreateRequest, RoleCreateDTO>().ReverseMap();
            CreateMap<RoleCreateDTO, Role>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<RolesToUserRequest, RolesToUserDTO>().ReverseMap();

            CreateMap<FeaturesToRoleRequest, FeaturesToRoleDTO>().ReverseMap();
        }
    }
}
