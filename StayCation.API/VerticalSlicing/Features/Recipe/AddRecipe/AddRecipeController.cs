using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe.Commands;

namespace StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe
{
    public class GetRecipeByIdController : BaseController
    {
        public GetRecipeByIdController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> AddRecipe(AddRecipeDTO addRecipeDTO)
        {
            var result = await _mediator.Send(new AddRecipeCommand(addRecipeDTO));

            return ResultDTO.Success(result.Data);
        }
    }
}
