using StayCation.API.DTOs.UserDTOs;
using StayCation.API.DTOs;
using MediatR;
using StayCation.API.Repositories;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Enums;
using StayCation.API.Exceptions;

namespace StayCation.API.CQRS.Users.Commands
{
    public record LoginUserCommand(UserLoginDTO UserLoginDTO) : IRequest<bool>;
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, bool>
    {
        IRepository<User> _repository;
        public LoginUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.First(c => c.EmailAddress == request.UserLoginDTO.EmailAddress);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.UserLoginDTO.Password, user.Password))
            {
                throw new BusinessException(ErrorCode.InvalidData, "Invalid credentials");
            }

            var userDTO = user.MapOne<UserDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return true;
        }
    }
}
