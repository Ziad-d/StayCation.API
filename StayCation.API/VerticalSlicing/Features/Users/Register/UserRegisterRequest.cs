namespace StayCation.VerticalSlicing.Features.Users.Register
{
    public class UserRegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
