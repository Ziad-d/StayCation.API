using MediatR;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Data.Repositories;

namespace StayCation.API.VerticalSlicing.Common.Helpers
{
    public abstract class BaseRequestHandler<TEntity, TRequest, TResponse> : 
                        IRequestHandler<TRequest, TResponse> 
                        where TRequest : IRequest<TResponse> 
                        where TEntity : BaseModel
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        protected readonly IRepository<TEntity> _repository;

        public BaseRequestHandler(RequestParameters<TEntity> requestParameters)
        {
            _mediator = requestParameters.Mediator;
            _userState = requestParameters.UserState;
            _repository = requestParameters.Repository;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
