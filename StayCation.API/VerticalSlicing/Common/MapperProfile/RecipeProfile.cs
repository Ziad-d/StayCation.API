using AutoMapper;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe;
using StayCation.API.VerticalSlicing.Features.Recipe.GetRecipeById;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, AddRecipeDTO>();
            CreateMap<Recipe, RecipeReturnDTO>();
        }
    }
}
