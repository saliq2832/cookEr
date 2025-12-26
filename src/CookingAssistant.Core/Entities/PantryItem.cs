using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingAssistant.Core.Entities
{
    public class PantryItem
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty; // "pieces", "g", "kg", "L", "ml"
        public string Category { get; set; } = string.Empty; // "dairy", "vegetables", "spices"
        public DateTime? ExpirationDate { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;

        public bool IsExpiringSoon => ExpirationDate.HasValue &&
                                       ExpirationDate.Value <= DateTime.UtcNow.AddDays(3);
        public bool IsExpired => ExpirationDate.HasValue &&
                                  ExpirationDate.Value < DateTime.UtcNow;
    }
}
