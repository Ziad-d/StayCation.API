using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Users.ResetPassword.Commands;

namespace StayCation.API.VerticalSlicing.Features.Users.ResetPassword
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : BaseController
    {

        public ResetPasswordController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {

            var resultDTO = await _mediator.Send(resetPasswordRequest.MapOne<ResetPasswordCommand>());

            
            return resultDTO;
        }
    }
}
