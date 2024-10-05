using MediatR;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace StayCation.API.VerticalSlicing.Features.Users.VerifyAccount.Commands
{
    public record VerifyAccountCommand() : IRequest<ResultDTO>
    {
        public string EmailAddress { get; set; }
        public string OTP { get; set; }
    }

    public class VerifyAccountCommandHandler : BaseRequestHandler<User, VerifyAccountCommand, ResultDTO>
    {

        public VerifyAccountCommandHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAll()
                                .Where(u => u.EmailAddress == request.EmailAddress &&
                                            u.OTP == request.OTP &&
                                            !u.IsEmailVerified)
                                .FirstOrDefaultAsync();


            if (user is null)
            {
                return ResultDTO.Failure("Email or OTP is incorrect");
            }

            user.IsEmailVerified = true;

            _repository.Update(user);

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Verify Account Successfully!");
        }

    }
}
