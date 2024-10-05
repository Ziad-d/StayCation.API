using MediatR;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Common.DTOs;
using Microsoft.EntityFrameworkCore;

namespace StayCation.API.VerticalSlicing.Features.Users.ChangePassword.Commands
{
    public record ChangePasswordCommand(string Email) : IRequest<ResultDTO>;


    public class ChangePasswordCommandHandler : BaseRequestHandler<User, ChangePasswordCommand, ResultDTO>
    {

        public ChangePasswordCommandHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {

            var user = await _repository.GetAll()
                               .Where(u => u.EmailAddress == request.Email
                                       && u.IsEmailVerified)
                               .FirstOrDefaultAsync();

            if (user is null)
            {
                return ResultDTO.Failure("Email is incorrect!");
            }


            user.OTP = OTPGenerator.CreateOTP();

            user = _repository.Update(user);

            await _repository.SaveChangesAsync();

            EmailSenderDTO emailSenderDTO = new EmailSenderDTO()
            {
                ToEmail = user.EmailAddress,
                Subject = "Change your Password",
                Body = $"Please Change your Password by OTP : {user.OTP}"
            };

            EmailSender.SendEmail(emailSenderDTO);

            var changePasswordDTO = user.MapOne<ChangePasswordDTO>();

            return ResultDTO.Success(changePasswordDTO, "Change Password to this Email successfully!");
        }
    }
}