using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Features.Recipe.DeleteRecipe.Commands;

namespace StayCation.API.VerticalSlicing.Features.Recipe.DeleteRecipe
{
    public class DeleteRecipeController : BaseController
    {
        public DeleteRecipeController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> DeleteRecipe(int id)
        {
            var result = await _mediator.Send(new DeleteRecipeCommand(id));

            return ResultDTO.Success(result.Data);
        }
    }
}
