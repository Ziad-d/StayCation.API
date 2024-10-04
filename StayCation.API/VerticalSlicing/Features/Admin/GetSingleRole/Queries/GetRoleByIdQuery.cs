using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;


namespace StayCation.API.VerticalSlicing.Features.Admin.GetSingleRole.Queries
{
    public record GetRoleByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetRoleByIdQueryHandler : BaseRequestHandler<Role, GetRoleByIdQuery, ResultDTO>
    {
        public GetRoleByIdQueryHandler(RequestParameters<Role> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid RoleID!");
            }

            var role = await _repository.GetByIDAsync(request.id);
            var mappedRole = role.MapOne<RoleDTO>();
                
            return ResultDTO.Success(mappedRole, "Role has been retrieved successfully!");
        }
    }
}
