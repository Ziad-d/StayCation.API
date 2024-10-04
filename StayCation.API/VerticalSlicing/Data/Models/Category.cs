namespace StayCation.API.VerticalSlicing.Data.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
