using System;

namespace Backend.DTOs
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public double Height { get; set; }
        public string FormerClub { get; set; }
        public decimal TransferCost { get; set; }
        public decimal CurrentMarketValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}