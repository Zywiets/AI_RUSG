using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}