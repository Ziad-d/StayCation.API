using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Data.Repositories;

namespace StayCation.API.VerticalSlicing.Common
{
    public class RequestParameters <T> where T : BaseModel
    {
        public IMediator Mediator { get; set; }
        public UserState UserState { get; set; }
        public IRepository<T> Repository { get; set; }

        public RequestParameters(IMediator mediator,
            UserState userState
            , IRepository<T> repository
            )
        {
            Mediator = mediator;
            UserState = userState;
            Repository = repository;
        }
    }
}
