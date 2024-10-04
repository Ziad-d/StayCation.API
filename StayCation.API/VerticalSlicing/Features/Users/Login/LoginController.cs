using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;

namespace StayCation.API.VerticalSlicing.Features.Users.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(ControllereParameters controllereParameters) 
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Login(UserLoginRequest user)
        {

            var UserLoginDTO = user.MapOne<UserLoginDTO>();
            var result = await _mediator.Send(new LoginUserCommand(UserLoginDTO));

            return result;
        }
    }
}
