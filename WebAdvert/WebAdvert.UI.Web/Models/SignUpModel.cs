using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAdvert.UI.Web.Models
{
    public class SignUpModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(6, ErrorMessage = "Minimum length for password must be at least 6 chars.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and it's confirmation do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Enter your phone numbers")]
        public string PhoneNumber { get; set; }

        [Required] 
        [Display(Name = "Select your gender.")]
        public int Gender { get; set; }
    }
}