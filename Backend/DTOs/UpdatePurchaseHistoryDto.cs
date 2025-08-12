using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UpdatePurchaseHistoryDto
    {
        [StringLength(200)]
        public string ProductName { get; set; }
        
        [StringLength(100)]
        public string Category { get; set; }
        
        [StringLength(50)]
        public string Size { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int? Quantity { get; set; }
        
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        public decimal? UnitPrice { get; set; }
        
        [StringLength(500)]
        public string Notes { get; set; }
    }
}