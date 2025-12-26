using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingAssistant.Core.DTOs
{
    public class Dtos
    {
        public record CreatePantryItemDto(
            string Name,
            decimal Quantity,
            string Unit,
            string Category,
            DateTime? ExpirationDate
        );

        public record UpdatePantryItemDto(
            decimal? Quantity,
            DateTime? ExpirationDate
        );

        public record PantryItemResponseDto(
            Guid Id,
            string Name,
            decimal Quantity,
            string Unit,
            string Category,
            DateTime? ExpirationDate,
            bool IsExpiringSoon,
            bool IsExpired,
            DateTime AddedAt
        );
    }
}
