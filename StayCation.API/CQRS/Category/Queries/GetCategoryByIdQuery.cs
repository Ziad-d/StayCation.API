using MediatR;
using StayCation.API.DTOs;
using StayCation.API.Enums;
using StayCation.API.Exceptions;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Category.Queries
{
    public record GetCategoryByIdQuery(int id):IRequest<ResultDTO>;

    public class GetCategoryByIdQueryHandler : BaseRequestHandler<Models.Category, GetCategoryByIdQuery, ResultDTO>
    {
        public GetCategoryByIdQueryHandler(RequestParameters requestParameters, IRepository<Models.Category> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<ResultDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return  ResultDTO.Failure("Invalid CategoryID!");
            }

            var Category = await _repository.GetByIDAsync(request.id); 
            return ResultDTO.Success(Category);
        }
    }

           


}
