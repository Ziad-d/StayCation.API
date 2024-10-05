using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.VerticalSlicing.Features.Users.Register;
using StayCation.VerticalSlicing.Features.Users.Register.Commands;

namespace StayCation.API.VerticalSlicing.Features.Users.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {
        public RegisterController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Register(UserRegisterRequest user)
        {
            var result = await _mediator.Send(user.MapOne<RegisterUserCommand>());

            return result;
        }

    }
}
