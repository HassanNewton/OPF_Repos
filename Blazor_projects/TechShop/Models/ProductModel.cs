namespace TechShop.Models;

public class ProductModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
}

//varje produkt är ett objekt

//JSON → C# sker automatiskt via HttpClient