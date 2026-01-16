using System.ComponentModel.DataAnnotations;

namespace MyApi.ProductionLike.DTOs;

// DTO för uppdatering.
// Ofta vill man ha en separat DTO även här för att styra vad som får ändras.
public class UpdateProductDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;

    [Range(0, 1_000_000)]
    public decimal Price { get; set; }
}