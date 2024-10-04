using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Users.Login;

namespace StayCation.VerticalSlicing.Features.Users.Login.Commands
{
    public record LoginUserCommand(UserLoginDTO UserLoginDTO) : IRequest<ResultDTO>;

    public class LoginUserCommandHandler : BaseRequestHandler<User, LoginUserCommand, ResultDTO>
    {
        public LoginUserCommandHandler(RequestParameters<User> requestParameters) 
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.First(c => c.EmailAddress == request.UserLoginDTO.EmailAddress);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.UserLoginDTO.Password, user.Password))
            {
                return ResultDTO.Failure("Invalid credentials");
            }

            var userDTO = user.MapOne<UserForTokenDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return ResultDTO.Success(token, "User is logged in!");
        }
    }
}
