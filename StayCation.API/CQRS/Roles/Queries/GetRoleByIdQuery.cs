using MediatR;
using StayCation.API.DTOs.RoleDTOs;
using StayCation.API.Enums;
using StayCation.API.Exceptions;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Roles.Queries
{
    public record GetRoleByIdQuery(int id) : IRequest<RoleDTO>;
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDTO>
    {
        private readonly IRepository<Role> _repository;

        public GetRoleByIdQueryHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }
        public async Task<RoleDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.InvalidRoleID, "Invalid RoleID!");
            }

            var role = _repository.GetByID(request.id).MapOne<RoleDTO>();
            return role;
        }
    }
}
