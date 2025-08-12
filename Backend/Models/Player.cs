using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Player
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        
        public double Height { get; set; } // in cm
        
        [StringLength(100)]
        public string FormerClub { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TransferCost { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentMarketValue { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}