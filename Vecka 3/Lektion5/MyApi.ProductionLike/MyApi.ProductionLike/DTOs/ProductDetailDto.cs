namespace MyApi.ProductionLike.DTOs;

// DTO för detaljerad vy (t.ex. GET /api/products/5)
// Här kan vi inkludera mer än i listan, men fortfarande styra exakt vad som exponeras.
public class ProductDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime CreatedUtc { get; set; }
}