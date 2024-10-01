using MediatR;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleDTOs;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Roles.Queries
{
    public record GetRoleByIdQuery(int id) : IRequest<ResultDTO>;
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, ResultDTO>
    {
        private readonly IRepository<Role> _repository;

        public GetRoleByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<ResultDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
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
