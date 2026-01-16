using Microsoft.AspNetCore.Mvc;
using MyApi.BadDesign.Models;

namespace MyApi.BadDesign.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    // ❌ DÅLIG DESIGN:
    // - Detta är vår "fejk-databas"
    // - Den ligger i minnet
    // - Den delas av alla requests
    // - Den försvinner när appen startas om
    private static List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Pen", Price = 10 },
        new Product { Id = 2, Name = "Book", Price = 50 }
    };

    // GET: api/products
    [HttpGet]
    public IActionResult GetAll()
    {
        // ❌ Controller hämtar data direkt
        return Ok(_products);
    }

    // GET: api/products/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        // ❌ Controller letar i listan
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public IActionResult Create(Product newProduct)
    {
        // ❌ Controller skapar ID manuellt
        newProduct.Id = _products.Max(p => p.Id) + 1;

        // ❌ Controller muterar data
        _products.Add(newProduct);

        return CreatedAtAction(
            nameof(GetById),
            new { id = newProduct.Id },
            newProduct
        );
    }

    // PUT: api/products/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, Product updatedProduct)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);

        if (existingProduct == null)
            return NotFound();

        // ❌ Controller uppdaterar affärsdata
        existingProduct.Name = updatedProduct.Name;
        existingProduct.Price = updatedProduct.Price;

        return NoContent();
    }

    // DELETE: api/products/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);

        if (product == null)
            return NotFound();

        _products.Remove(product);
        return NoContent();
    }
}