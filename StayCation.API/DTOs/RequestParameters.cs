using MediatR;

namespace StayCation.API.DTOs
{
    public class RequestParameters
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }

        public RequestParameters(IMediator mediator
            , UserState userState
            )
        {
            Mediator = mediator;
            UserState = userState;
        }
    }
}
