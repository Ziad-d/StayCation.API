using MediatR;
using Microsoft.EntityFrameworkCore;
using StayCation.API.DTOs;
using StayCation.API.Enums;
using StayCation.API.Exceptions;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Category.Queries
{
    public record IsCategoryExistQuery(int id):IRequest<bool>;

    public class IsCategoryExistQueryHandler : BaseRequestHandler<Models.Category, IsCategoryExistQuery, bool>
    {
        public IsCategoryExistQueryHandler(RequestParameters requestParameters, IRepository<Models.Category> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<bool> Handle(IsCategoryExistQuery request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new BusinessException(ErrorCode.InvalidData, "Invalid CategoryID!");
            }

            var project = _repository.GetAll();
           bool IsExist = await  project.Where(x => x.Id == request.id).AnyAsync();
            return IsExist;

        }
    }
}
