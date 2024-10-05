using AutoMapper;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Users.ChangePassword;
using StayCation.API.VerticalSlicing.Features.Users.Login;
using StayCation.API.VerticalSlicing.Features.Users.Register;
using StayCation.API.VerticalSlicing.Features.Users.ResetPassword;
using StayCation.API.VerticalSlicing.Features.Users.ResetPassword.Commands;
using StayCation.API.VerticalSlicing.Features.Users.VerifyAccount;
using StayCation.API.VerticalSlicing.Features.Users.VerifyAccount.Commands;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;
using StayCation.VerticalSlicing.Features.Users.Register;
using StayCation.VerticalSlicing.Features.Users.Register.Commands;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserForTokenDTO>().ReverseMap();
                //.ForMember(dest => dest.RoleIds, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.RoleId).ToList()));

            CreateMap<User, ChangePasswordDTO>().ReverseMap();

            CreateMap<UserRegisterRequest, RegisterUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UserRegisterDTO>().ReverseMap();

            CreateMap<UserLoginRequest, LoginUserCommand>().ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordCommand>().ReverseMap();

            CreateMap<VerifyAccountRequest, VerifyAccountCommand>().ReverseMap();
        }
    }
}
