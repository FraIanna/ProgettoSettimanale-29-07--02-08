using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale_29_07__02_08.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Nome")]
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80)]
        [Display(Name = "Email")]
        public required string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Conferma Password")]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Le password non corrispondono.")]
        public required string ConfirmPassword { get; set; }
    }
}
