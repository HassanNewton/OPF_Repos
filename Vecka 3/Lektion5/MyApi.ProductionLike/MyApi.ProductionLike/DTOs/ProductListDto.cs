namespace MyApi.ProductionLike.DTOs;

// DTO (Data Transfer Object) = hur data skickas UT från API:t.
// Denna DTO är för listor: vi skickar bara det som behövs i en lista.
public class ProductListDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
}