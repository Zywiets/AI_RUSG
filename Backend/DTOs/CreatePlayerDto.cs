using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CreatePlayerDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [Range(16, 50, ErrorMessage = "Age must be between 16 and 50")]
        public int Age { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        
        [Required]
        [Range(150, 220, ErrorMessage = "Height must be between 150cm and 220cm")]
        public double Height { get; set; }
        
        [StringLength(100)]
        public string FormerClub { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "Transfer cost must be non-negative")]
        public decimal TransferCost { get; set; }
        
        [Range(0, double.MaxValue, ErrorMessage = "Market value must be non-negative")]
        public decimal CurrentMarketValue { get; set; }
    }
}