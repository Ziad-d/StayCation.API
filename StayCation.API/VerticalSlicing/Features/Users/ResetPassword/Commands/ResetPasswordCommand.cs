using MediatR;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace StayCation.API.VerticalSlicing.Features.Users.ResetPassword.Commands
{
    public class ResetPasswordCommand() : IRequest<ResultDTO>
    {
        public string EmailAddress { get; set; }
        public string OTP { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }



    public class ResetPasswordCommandHandler : BaseRequestHandler<User, ResetPasswordCommand, ResultDTO>
    {

        public ResetPasswordCommandHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.NewPassword != request.ConfirmNewPassword)
            {
                return ResultDTO.Failure("Confirm New Password does not match the New Password.");
            }

            var user = await _repository.GetAll()
                               .Where(u => u.EmailAddress == request.EmailAddress
                                        && u.OTP == request.OTP
                                        && u.IsEmailVerified)
                               .FirstOrDefaultAsync();

            if (user is null)
            {
                return ResultDTO.Failure("Email or OTP is incorrect!");
            }

            user.Password = PasswordHelper.CreatePasswordHash(request.NewPassword);

            _repository.Update(user);

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Reset New Password successfully!");
        }
    }
}
