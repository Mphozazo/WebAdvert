using System.ComponentModel.DataAnnotations;

namespace WebAdvert.UI.Web.Models
{
    public class ConfirmationModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string  VerificationCode { get; set; }
    }
}
