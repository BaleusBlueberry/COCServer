using System.ComponentModel.DataAnnotations;

namespace COCServer.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(2), MaxLength(21)] 
        public required string Password { get; set; }
    }
}
