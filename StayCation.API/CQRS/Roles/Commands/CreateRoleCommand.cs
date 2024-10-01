using MediatR;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleDTOs;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Roles.Commands
{
    public record CreateRoleCommand(RoleCreateDTO RoleCreateDTO) : IRequest<ResultDTO>;

    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, ResultDTO>
    {
        private readonly IRepository<Role> _repository;

        public CreateRoleCommandHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public async Task<ResultDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if(request.RoleCreateDTO.Name == null)
            {
                return ResultDTO.Failure("Name is required");

            }
            var roleFound = await _repository.First(r => r.Name == request.RoleCreateDTO.Name);

            if (roleFound is not null)
            {
                return ResultDTO.Failure("Role with that name already exits!");
            }

            var role = request.RoleCreateDTO.MapOne<Role>();
            await _repository.AddAsync(role);
            await _repository.SaveChangesAsync();
            return ResultDTO.Success("Role has been created successfully!");
        }
    }
}
