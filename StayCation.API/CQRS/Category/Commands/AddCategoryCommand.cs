using MediatR;
using StayCation.API.DTOs;
using StayCation.API.DTOs.CategoryDTO;
using StayCation.API.Helpers;
using StayCation.API.Models;
using StayCation.API.Repositories;

namespace StayCation.API.CQRS.Category.Commands
{
    public record AddCategoryCommand(AddCategoryDTO AddCategoryDTO) : IRequest<ResultDTO>;

    public class AddCategoryCommandHandler : BaseRequestHandler<Models.Category, AddCategoryCommand, ResultDTO>
    {
        public AddCategoryCommandHandler(RequestParameters requestParameters, IRepository<Models.Category> repository) : base(requestParameters, repository)
        {
        }

        public override async Task<ResultDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.AddCategoryDTO.MapOne<Models.Category>();
            category = await _repository.AddAsync(category);

            return ResultDTO.Success(category);
           
        }
    }
}
