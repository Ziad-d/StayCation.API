using MediatR;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Data.Repositories;

namespace StayCation.API.VerticalSlicing.Features.Category.AddCategory.Commands
{
    public record AddCategoryCommand(AddCategoryDTO AddCategoryDTO) : IRequest<ResultDTO>;

    public class AddCategoryCommandHandler : BaseRequestHandler<Data.Models.Category, AddCategoryCommand, ResultDTO>
    {
        public AddCategoryCommandHandler(RequestParameters<Data.Models.Category> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = request.AddCategoryDTO.MapOne<Data.Models.Category>();
            category = await _repository.AddAsync(category);

            return ResultDTO.Success(category);

        }
    }
}
