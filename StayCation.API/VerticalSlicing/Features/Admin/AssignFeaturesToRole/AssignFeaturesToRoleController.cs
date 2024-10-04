using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.Attributes;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Enums;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Admin.AssignFeaturesToRole.Orchestrators;
using StayCation.VerticalSlicing.Features.Admin.GetSingleRole;

namespace StayCation.API.VerticalSlicing.Features.Admin.AssignFeaturesToRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignFeaturesToRoleController : BaseController
    {
        public AssignFeaturesToRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignFeaturesToRole })]
        public async Task<ResultDTO> AssignFeaturesToRole(FeaturesToRoleRequest featuresToRoleRequest)
        {
            var featuresToRoleDTO = featuresToRoleRequest.MapOne<FeaturesToRoleDTO>();
            var result = await _mediator.Send(new AssignFeaturesToRoleOrchestrator(featuresToRoleDTO));
            return result;
        }
    }
}
