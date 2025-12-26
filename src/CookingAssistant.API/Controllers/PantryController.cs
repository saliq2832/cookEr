using CookingAssistant.Core.Entities;
using CookingAssistant.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CookingAssistant.Core.DTOs.Dtos;

namespace CookingAssistant.API.Controllers
{
    public class PantryController : ControllerBase
    {
        private readonly AppDbContext _context;

        // TODO: Replace with actual user authentication
        private readonly Guid _currentUserId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        public PantryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PantryItemResponseDto>>> GetAll()
        {
            var items = await _context.PantryItems
                .Where(p => p.UserId == _currentUserId)
                .OrderBy(p => p.ExpirationDate)
                .Select(p => new PantryItemResponseDto(
                    p.Id,
                    p.Name,
                    p.Quantity,
                    p.Unit,
                    p.Category,
                    p.ExpirationDate,
                    p.IsExpiringSoon,
                    p.IsExpired,
                    p.AddedAt
                ))
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("expiring")]
        public async Task<ActionResult<IEnumerable<PantryItemResponseDto>>> GetExpiring()
        {
            var threeDaysFromNow = DateTime.UtcNow.AddDays(3);

            var items = await _context.PantryItems
                .Where(p => p.UserId == _currentUserId &&
                            p.ExpirationDate != null &&
                            p.ExpirationDate <= threeDaysFromNow)
                .OrderBy(p => p.ExpirationDate)
                .Select(p => new PantryItemResponseDto(
                    p.Id,
                    p.Name,
                    p.Quantity,
                    p.Unit,
                    p.Category,
                    p.ExpirationDate,
                    p.IsExpiringSoon,
                    p.IsExpired,
                    p.AddedAt
                ))
                .ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<PantryItemResponseDto>> Create(CreatePantryItemDto dto)
        {
            var item = new PantryItem
            {
                Id = Guid.NewGuid(),
                UserId = _currentUserId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Unit = dto.Unit,
                Category = dto.Category,
                ExpirationDate = dto.ExpirationDate,
                AddedAt = DateTime.UtcNow
            };

            _context.PantryItems.Add(item);
            await _context.SaveChangesAsync();

            var response = new PantryItemResponseDto(
                item.Id,
                item.Name,
                item.Quantity,
                item.Unit,
                item.Category,
                item.ExpirationDate,
                item.IsExpiringSoon,
                item.IsExpired,
                item.AddedAt
            );

            return CreatedAtAction(nameof(GetAll), new { id = item.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePantryItemDto dto)
        {
            var item = await _context.PantryItems
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == _currentUserId);

            if (item == null)
                return NotFound();

            if (dto.Quantity.HasValue)
                item.Quantity = dto.Quantity.Value;

            if (dto.ExpirationDate.HasValue)
                item.ExpirationDate = dto.ExpirationDate.Value;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _context.PantryItems
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == _currentUserId);

            if (item == null)
                return NotFound();

            _context.PantryItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
