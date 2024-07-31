using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale_29_07__02_08.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [StringLength(80)]
        public required string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Le password non combaciano, riprova.")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public required string ConfirmPassword { get; set; }
    }
}
