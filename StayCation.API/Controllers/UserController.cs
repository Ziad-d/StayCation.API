using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayCation.API.Attributes;
using StayCation.API.CQRS.UserRoles.Orchestrators;
using StayCation.API.CQRS.Users.Commands;
using StayCation.API.DTOs;
using StayCation.API.DTOs.UserDTOs;
using StayCation.API.DTOs.UserRoleDTOs;
using StayCation.API.Enums;

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
        public async Task<ResultDTO> Register(UserRegisterDTO user)
        {
            var result = await _mediator.Send(new RegisterUserCommand(user));

            return ResultDTO.Success(result);
        }

        [HttpPost]
        public async Task<ResultDTO> Login(UserLoginDTO user)
        {
            var result = await _mediator.Send(new LoginUserCommand(user));

            return result;
        }

        [HttpPost]
        [Authorize]
        [TypeFilter(typeof(CustomizedAuthorize), Arguments = new object[] { Feature.AssignRolesToUser })]
        public async Task<ResultDTO> AssignRolesToUser(RolesToUserDTO rolesToUserDTO)
        {
            var result = await _mediator.Send(new AssignRolesToUserOrchestrator(rolesToUserDTO));

            return result;
        }
    }
}
