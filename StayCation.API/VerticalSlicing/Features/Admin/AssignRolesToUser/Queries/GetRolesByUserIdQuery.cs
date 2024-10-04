using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Admin.CreateRole.Commands;


namespace StayCation.VerticalSlicing.Features.Admin.AssignRolesToUser.Queries
{
    public record GetRolesByUserIdQuery(int userId) : IRequest<IEnumerable<int>>;
    public class GetRolesByUserIdQueryHandler : BaseRequestHandler<UserRole, GetRolesByUserIdQuery, IEnumerable<int>>
    {
        public GetRolesByUserIdQueryHandler(RequestParameters<UserRole> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<IEnumerable<int>> Handle(GetRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userRoles = _repository.Get(ur => ur.UserId == request.userId);

            var roleIds = userRoles.Select(r => r.RoleId).ToList();

            return roleIds;
        }
    }
}
