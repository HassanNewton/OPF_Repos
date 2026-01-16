namespace MyApi.ProductionLike.Models;

// Entity = hur datan lagras i databasen (tabell).
// Den här klassen ska vi INTE skicka ut direkt i ett "riktigt" API,
// eftersom den kan ändras och ofta innehåller mer data än vi vill exponera.
// Därför använder vi DTOs + Projection i Projekt 3.
public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    // Exempel på fält som ofta finns i riktiga system,
    // men som vi kanske inte vill exponera i alla listor:
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}