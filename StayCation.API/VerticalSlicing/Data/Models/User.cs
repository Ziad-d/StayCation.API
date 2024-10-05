namespace StayCation.API.VerticalSlicing.Data.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string OTP { get; set; }
        public bool IsEmailVerified { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
