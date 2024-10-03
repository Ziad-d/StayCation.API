using MediatR;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.UserRoles.Queries
{
    public record GetRolesByUserIdQuery(int userId) : IRequest<IEnumerable<int>>;
    public class GetRolesByUserIdQueryHandler : IRequestHandler<GetRolesByUserIdQuery, IEnumerable<int>>
    {
        private readonly IRepository<UserRole> _repository;

        public GetRolesByUserIdQueryHandler(IRepository<UserRole> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<int>> Handle(GetRolesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var userRoles = _repository.Get(ur => ur.UserId == request.userId);

            var roleIds = userRoles.Select(r => r.RoleId).ToList();

            return roleIds;
        }
    }
}
