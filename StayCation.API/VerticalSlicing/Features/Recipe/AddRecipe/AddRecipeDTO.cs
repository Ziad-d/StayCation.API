namespace StayCation.API.VerticalSlicing.Features.Recipe.Add_Recipe
{
    public class AddRecipeDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Tag { get; set; }
        public int CategoryId { get; set; }
    }
}
