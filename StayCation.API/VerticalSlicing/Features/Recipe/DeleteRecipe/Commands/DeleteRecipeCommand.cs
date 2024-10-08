using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Common.Helpers;
using StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe.Commands;
using StayCation.API.VerticalSlicing.Features.Recipe.GetRecipeById;

namespace StayCation.API.VerticalSlicing.Features.Recipe.DeleteRecipe.Commands
{
    public record DeleteRecipeCommand(int id) : IRequest<ResultDTO>;
    public class DeleteRecipeCommandHandler : BaseRequestHandler<Data.Models.Recipe, DeleteRecipeCommand, ResultDTO>
    {
        public DeleteRecipeCommandHandler(RequestParameters<Data.Models.Recipe> requestParameters) : base(requestParameters)
        {
            
        }
        public override async Task<ResultDTO> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ResultDTO.Failure("Invalid RecipeID!");
            }

            _repository.Delete(request.id);
            return ResultDTO.Success("Deleted");
        }
    }
}
