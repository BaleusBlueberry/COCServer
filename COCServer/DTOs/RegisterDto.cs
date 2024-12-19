using System.ComponentModel.DataAnnotations;

namespace COCServer.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public required string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string PasswordConfirm { get; set; }

    }
}
