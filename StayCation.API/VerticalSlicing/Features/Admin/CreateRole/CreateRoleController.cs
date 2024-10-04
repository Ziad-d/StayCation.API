using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.Attributes;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Enums;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Admin.CreateRole.Commands;
using StayCation.VerticalSlicing.Features.Admin.CreateRole;

namespace StayCation.API.VerticalSlicing.Features.Admin.CreateRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateRoleController : BaseController
    {
        public CreateRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.CreateRole })]
        public async Task<ResultDTO> CreateRole(RoleCreateRequest roleCreateRequest)
        {
            var roleCreateDTO = roleCreateRequest.MapOne<RoleCreateDTO>();
            var command = new CreateRoleCommand(roleCreateDTO);
            var result = await _mediator.Send(command);
            return result;
        }


    }
}
