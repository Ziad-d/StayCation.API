namespace StayCation.API.Models
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
