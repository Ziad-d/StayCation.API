using Microsoft.AspNetCore.Mvc;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Features.Recipe.GetRecipeById.Queries;

namespace StayCation.API.VerticalSlicing.Features.Recipe.GetRecipeById
{
    public class DeleteRecipeController : BaseController
    {
        public DeleteRecipeController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> GetRecipeById(int id)
        {
            var result = await _mediator.Send(new GetRecipeByIdQuery(id));

            return ResultDTO.Success(result.Data);
        }
    }
}
