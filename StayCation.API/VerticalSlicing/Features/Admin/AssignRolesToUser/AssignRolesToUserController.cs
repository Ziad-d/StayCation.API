using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.Attributes;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Enums;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Admin.AssignRolesToUser.Orchestrators;
using StayCation.VerticalSlicing.Features.Admin.AssignRolesToUser;

namespace StayCation.API.VerticalSlicing.Features.Admin.AssignRolesToUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRolesToUserController : BaseController
    {
        public AssignRolesToUserController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignRolesToUser })]
        public async Task<ResultDTO> AssignRolesToUser(RolesToUserRequest rolesToUserRequest)
        {
            var rolesToUserDTO = rolesToUserRequest.MapOne<RolesToUserDTO>();

            var result = await _mediator.Send(new AssignRolesToUserOrchestrator(rolesToUserDTO));

            return result;
        }
    }
}
