using MediatR;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.CQRS.Users.Commands;
using StayCation.API.DTOs;
using StayCation.API.DTOs.UserDTOs;

namespace StayCation.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ResultDTO>> Register(UserRegisterDTO user)
        {
            var x = await _mediator.Send(new RegisterUserCommand(user));

            return Ok(x);
        }

        [HttpPost]
        public async Task<ActionResult<ResultDTO>> Login(UserLoginDTO user)
        {
            var x = await _mediator.Send(new LoginUserCommand(user));

            return Ok(x);
        }
    }
}
