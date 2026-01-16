namespace MyApi.EfCoreOnly.Models;

// Entity = databasmodell (tabell)
// Varje property blir en kolumn i tabellen.
//
// I Projekt 2 använder vi fortfarande denna klass både som:
// - Entity (databas)
// - API-kontrakt (det vi skickar ut)
//
// Det är okej i detta mellanläge, men i Projekt 3 inför vi DTOs + Projection.
public class Product
{
    // Id blir primärnyckel automatiskt i EF Core.
    public int Id { get; set; }

    // = null! betyder: "Jag lovar C# att detta får ett värde"
    // (EF Core + JSON-deserialisering kommer sätta värdet).
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }
}