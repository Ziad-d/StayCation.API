using AutoMapper;
using StayCation.API.VerticalSlicing.Common.DTOs.Category;
using StayCation.API.VerticalSlicing.Data.Models;

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
