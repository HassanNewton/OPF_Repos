using System.ComponentModel.DataAnnotations;

namespace MyApi.ProductionLike.DTOs;

// DTO för att SKAPA en produkt.
// Fördel: vi tar emot exakt de fält vi vill tillåta vid skapande.
// Vi använder också DataAnnotations för enkel validering.
public class CreateProductDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = null!;

    [Range(0, 1_000_000)]
    public decimal Price { get; set; }
}