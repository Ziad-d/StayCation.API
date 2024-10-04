namespace StayCation.API.VerticalSlicing.Data.Models
{
    public class Recipe : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Tag { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
