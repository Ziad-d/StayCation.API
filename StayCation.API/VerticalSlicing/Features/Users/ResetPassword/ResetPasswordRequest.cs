using System.ComponentModel.DataAnnotations;

namespace StayCation.API.VerticalSlicing.Features.Users.ResetPassword
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string OTP { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long, and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Confirm Password does not match the Password.")]
        public string ConfirmNewPassword { get; set; }
    }
}
