using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.CQRS.Roles.Commands;
using StayCation.API.CQRS.Roles.Queries;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleDTOs;

namespace StayCation.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResultDTO> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var command = new CreateRoleCommand(roleCreateDTO);
            var result = await _mediator.Send(command);
            return ResultDTO.Success(result);
        }

        [HttpGet("{id}")]
        public async Task<ResultDTO> GetSingleRole(int id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));
            return ResultDTO.Success(role);
        }
    }
}
