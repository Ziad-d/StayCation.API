using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Users.VerifyAccount.Commands;

namespace StayCation.API.VerticalSlicing.Features.Users.VerifyAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyAccountController : BaseController
    {

        public VerifyAccountController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> VerifyAccount(VerifyAccountRequest verifyAccountRequest)
        {

            var resultDTO = await _mediator.Send(verifyAccountRequest.MapOne<VerifyAccountCommand>());

            return resultDTO;
        }
    }
}
