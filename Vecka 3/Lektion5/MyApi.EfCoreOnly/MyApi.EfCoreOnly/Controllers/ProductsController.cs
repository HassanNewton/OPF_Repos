using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.EfCoreOnly.Data;
using MyApi.EfCoreOnly.Models;

namespace MyApi.EfCoreOnly.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    // DbContext injiceras här av ASP.NET Core (DI).
    // Detta är redan ett steg mot "riktig" arkitektur.
    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Async för att inte blockera tråden när databasen jobbar.
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    // GET: api/products/1
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        // FindAsync använder primärnyckeln (Id).
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create(Product newProduct)
    {
        // EF Core börjar spåra objektet och skapar en INSERT vid SaveChangesAsync.
        _context.Products.Add(newProduct);
        await _context.SaveChangesAsync();

        // Nu har newProduct.Id fått ett värde av databasen.
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    // PUT: api/products/1
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Product updatedProduct)
    {
        // Hämta befintlig rad först
        var existing = await _context.Products.FindAsync(id);

        if (existing == null)
            return NotFound();

        // Uppdatera fält
        existing.Name = updatedProduct.Name;
        existing.Price = updatedProduct.Price;

        // EF Core skapar en UPDATE vid SaveChangesAsync
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/products/1
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}