using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.Attributes;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Enums;
using StayCation.API.VerticalSlicing.Features.Admin.GetSingleRole.Queries;

namespace StayCation.API.VerticalSlicing.Features.Admin.GetSingleRole
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSingleRoleController : BaseController
    {
        public GetSingleRoleController(ControllereParameters controllereParameters)
                            : base(controllereParameters)
        {
        }

        [HttpGet("{id}")]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.GetSingleRole })]
        public async Task<ResultDTO> GetSingleRole(int id)
        {
            var role = await _mediator.Send(new GetRoleByIdQuery(id));
            return role;
        }
    }
}
