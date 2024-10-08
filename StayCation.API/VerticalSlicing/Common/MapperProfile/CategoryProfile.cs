using AutoMapper;
using StayCation.API.VerticalSlicing.Data.Models;
using StayCation.API.VerticalSlicing.Features.Category.AddCategory;

namespace StayCation.API.VerticalSlicing.Common.MapperProfile
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category,AddCategoryDTO>().ReverseMap();
        }

    }
}
