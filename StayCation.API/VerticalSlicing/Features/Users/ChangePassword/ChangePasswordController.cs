using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Features.Users.ChangePassword.Commands;

namespace StayCation.API.VerticalSlicing.Features.Users.ChangePassword
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : BaseController
    {

        public ChangePasswordController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> ChangePassword(string Email)
        {


            var resultDTO = await _mediator.Send(new ChangePasswordCommand(Email));

     
            return resultDTO;
        }
    }
}
