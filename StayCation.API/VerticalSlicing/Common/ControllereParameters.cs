using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;

namespace StayCation.API.VerticalSlicing.Common
{
    public class ControllereParameters
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }

        public ControllereParameters(IMediator mediator, UserState userState)
        {
            Mediator = mediator;
            UserState = userState;
        }
    }
}
