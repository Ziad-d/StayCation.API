using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.CQRS.RoleFeatures.Orchestrators;
using StayCation.API.DTOs;
using StayCation.API.DTOs.RoleFeatureDTOs;

namespace StayCation.API.Controllers
{
    [Route("[controller]/[aciton]")]
    [ApiController]
    public class RoleFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResultDTO> AssignFeaturesToRole(FeaturesToRoleDTO featuresToRoleDTO)
        {
            var result = await _mediator.Send(new AssignFeaturesToRoleOrchestrator(featuresToRoleDTO));
            return ResultDTO.Success(result);
        }
    }
}
