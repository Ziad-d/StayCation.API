using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.Attributes;
using StayCation.API.CQRS.RoleFeatures.Orchestrators;
using StayCation.API.CQRS.Roles.Commands;
using StayCation.API.CQRS.Roles.Queries;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleDTOs;
using StayCation.API.DTOs.RoleFeatureDTOs;
using StayCation.API.Enums;

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
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.CreateRole })]
        public async Task<ResultDTO> CreateRole(RoleCreateDTO roleCreateDTO)
        {
            var command = new CreateRoleCommand(roleCreateDTO);
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.GetSingleRole })]
        public async Task<ResultDTO> GetSingleRole(int id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));
            return role;
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignFeaturesToRole })]
        public async Task<ResultDTO> AssignFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO)
        {
            var result = await _mediator.Send(new AssignFeaturesToRoleOrchestrator(featuresToRoleDTO));
            return result;
        }
    }
}
