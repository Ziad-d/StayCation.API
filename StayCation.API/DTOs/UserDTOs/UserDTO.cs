namespace StayCation.API.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public List<int> RoleIds { get; set; } = new List<int>();
        public string UserName { get; set; }
    }
}
