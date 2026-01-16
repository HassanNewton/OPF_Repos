using Microsoft.AspNetCore.Mvc;
using MyApi.ProductionLike.DTOs;
using MyApi.ProductionLike.Services;

namespace MyApi.ProductionLike.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    // Controllern får en abstraktion (interface) och vet inte:
    // - vilken databas som används
    // - hur logiken implementeras
    // Detta är DIP + DI i praktiken.
    public ProductsController(IProductService service)
    {
        _service = service;
    }

    // GET: api/products
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _service.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductDto dto)
    {
        // Eftersom [ApiController] är aktivt:
        // Om dto är ogiltig (Required/Range/MinLength) returneras 400 automatiskt.
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/products/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/products/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}