namespace MyApi.BadDesign.Models;

// Denna klass representerar en produkt.
// I detta projekt används den BÅDE som:
// - datamodell
// - API-respons
// Detta är okej här, men blir ett problem senare.
public class Product
{
    // Id sätts manuellt i controllern (dålig idé)
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}