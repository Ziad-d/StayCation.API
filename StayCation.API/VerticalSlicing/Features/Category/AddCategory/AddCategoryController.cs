using Microsoft.AspNetCore.Mvc;
using Serilog;
using StayCation.API.VerticalSlicing.Common;
using StayCation.API.VerticalSlicing.Common.DTOs;
using StayCation.API.VerticalSlicing.Features.Category.AddCategory.Commands;
using StayCation.API.VerticalSlicing.Features.Users.Login;
using StayCation.VerticalSlicing.Features.Users.Login.Commands;

namespace StayCation.API.VerticalSlicing.Features.Category.AddCategory
{
    public class AddCategoryController : BaseController
    {
        public AddCategoryController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }
        [HttpPost]
        public async Task<ResultDTO> AddCategory(AddCategoryDTO addCategory)
        {

            var result = await _mediator.Send(new AddCategoryCommand(addCategory));

            return result;
        }

    }
}
