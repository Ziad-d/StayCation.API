using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StayCation.API.VerticalSlicing.Common.Constants;
using StayCation.API.VerticalSlicing.Common.DTOs;
using System.Security.Claims;

namespace StayCation.API.VerticalSlicing.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        public BaseController(ControllereParameters controllereParameters)
        {
            _mediator = controllereParameters.Mediator;
            _userState = controllereParameters.UserState;

            var loggedUser = new HttpContextAccessor().HttpContext.User;


            _userState.Id = loggedUser?.FindFirst(CustomClaimTypes.Id)?.Value ?? "";
            _userState.Email = loggedUser?.FindFirst(CustomClaimTypes.Email)?.Value ?? "";
            _userState.UserName = loggedUser?.FindFirst(CustomClaimTypes.UserName)?.Value ?? "";

           // Log.Information("User {UserId} ({Email}) made a request to {ControllerName}/{ActionName}",
           //_userState.Id, _userState.Email, this.ControllerContext.RouteData.Values["controller"], this.ControllerContext.RouteData.Values["action"]);


        }
    }
}
