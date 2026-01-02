namespace Pizzas.Models;

public class PizzaModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Deliciousness { get; set; }
    public string ImageUrl { get; set; }
}

//Detta är exakt den struktur JSON-datan kommer ha

//Blazor kan automatiskt mappa JSON → objekt