using System.ComponentModel.DataAnnotations;

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
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password does not match the Password.")]
        public string ConfirmPassword { get; set; }
    }
}
