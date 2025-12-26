using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingAssistant.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? DietaryPreferences { get; set; } // JSON: ["vegetarian", "no-nuts"]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<PantryItem> PantryItems { get; set; } = new List<PantryItem>();
    }
}
