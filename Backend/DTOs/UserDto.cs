using System;
using System.Collections.Generic;

namespace Backend.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PurchaseHistoryDto> PurchaseHistory { get; set; } = new List<PurchaseHistoryDto>();
    }
}