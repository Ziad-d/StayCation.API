using MediatR;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;

namespace StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe.Commands
{
    public record AddRecipeCommand(AddRecipeDTO AddRecipeDTO) : IRequest<ResultDTO>;
    public class AddRecipeCommandHandler : BaseRequestHandler<Data.Models.Recipe, AddRecipeCommand, ResultDTO>
    {
        public AddRecipeCommandHandler(RequestParameters<Data.Models.Recipe> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(AddRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = request.AddRecipeDTO.MapOne<Data.Models.Recipe>();
            await _repository.AddAsync(recipe);

            return ResultDTO.Success(recipe);
        }
    }
}
