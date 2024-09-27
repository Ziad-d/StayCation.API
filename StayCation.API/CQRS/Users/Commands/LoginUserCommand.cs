using StayCation.API.DTOs.UserDTOs;
using StayCation.API.DTOs;
using MediatR;
using StayCation.API.Repositories;
using StayCation.API.Helpers;
using FoodApp.API.Models;

namespace StayCation.API.CQRS.Users.Commands
{
    public record LoginUserCommand(UserLoginDTO UserLoginDTO) : IRequest<ResultDTO>;
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultDTO>
    {
        IRepository<User> _repository;
        public LoginUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ResultDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.First(c => c.EmailAddress == request.UserLoginDTO.EmailAddress);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.UserLoginDTO.Password, user.Password))
            {
                return ResultDTO.Faliure("Invalid credentials");
            }

            var userDTO = user.MapOne<UserDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return ResultDTO.Sucess(token, "User is logged in");
        }
    }
}
