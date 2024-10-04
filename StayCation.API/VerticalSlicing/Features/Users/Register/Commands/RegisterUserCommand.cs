using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Users.Register;

namespace StayCation.VerticalSlicing.Features.Users.Register.Commands
{
    public record RegisterUserCommand
        (string FirstName 
        ,string LastName 
        ,string UserName
        ,string EmailAddress
        ,string PhoneNumber
        ,string Country
        ,string Password
        ,string ConfirmPassword) : IRequest<ResultDTO>;
    public class RegisterUserCommandHandler : BaseRequestHandler<User, RegisterUserCommand, ResultDTO>
    {
        public RegisterUserCommandHandler(RequestParameters<User> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailAddress = await _repository.First(u => u.EmailAddress == request.EmailAddress);

            if (emailAddress is not null)
            {
                return ResultDTO.Failure("Email Address already exists!");
            }

            var userName = await _repository.First(user => user.UserName == request.UserName);

            if (userName is not null)
            {
                return ResultDTO.Failure("Username already exists!");
            }

            var user = request.MapOne<User>();
            user.Password = PasswordHelper.CreatePasswordHash(request.Password);
            user = await _repository.AddAsync(user);

            var mappedUser = user.MapOne<UserRegisterDTO>();

            return ResultDTO.Success(mappedUser, "User has been registered successfully!");
        }
    }
}
