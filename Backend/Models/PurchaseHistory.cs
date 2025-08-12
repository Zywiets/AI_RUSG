using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        
        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }
        
        [StringLength(100)]
        public string Category { get; set; } // Jersey, Scarf, Hat, etc.
        
        [StringLength(50)]
        public string Size { get; set; }
        
        public int Quantity { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
        
        [StringLength(500)]
        public string Notes { get; set; }
        
        // Navigation property
        public virtual User User { get; set; }
    }
}