using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UpdateUserDto
    {
        [StringLength(50)]
        public string Username { get; set; }
        
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}