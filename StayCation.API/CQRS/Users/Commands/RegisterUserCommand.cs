using MediatR;
using StayCation.API.DTOs;
using StayCation.API.DTOs.UserDTOs;
using StayCation.API.Enums;
using StayCation.API.Exceptions;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Users.Commands
{
    public record RegisterUserCommand(UserRegisterDTO userRegisterDTO) : IRequest<bool>;
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        IRepository<User> _repository;

        public RegisterUserCommandHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailAddress = await _repository.First(u => u.EmailAddress == request.userRegisterDTO.EmailAddress);

            if (emailAddress is not null)
            {
                throw new BusinessException(ErrorCode.Exists, "Email Address already exists!");
            }

            var userName = await _repository.First(user => user.UserName == request.userRegisterDTO.UserName);

            if (userName is not null)
            {
                throw new BusinessException(ErrorCode.Exists, "Username already exists!");
            }

            var user = request.userRegisterDTO.MapOne<User>();
            user.Password = PasswordHelper.CreatePasswordHash(request.userRegisterDTO.Password);
            user = await _repository.AddAsync(user);

            return true;
        }
    }
}
