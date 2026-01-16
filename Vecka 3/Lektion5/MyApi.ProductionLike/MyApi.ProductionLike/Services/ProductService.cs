using Microsoft.EntityFrameworkCore;
using MyApi.ProductionLike.Data;
using MyApi.ProductionLike.DTOs;
using MyApi.ProductionLike.Models;

namespace MyApi.ProductionLike.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    // Projection: vi väljer exakt vilka fält som skickas ut.
    // Detta gör att vi INTE behöver returnera Product-entity direkt.
    public async Task<List<ProductListDto>> GetAllAsync()
    {
        return await _context.Products
            .OrderBy(p => p.Id)
            .Select(p => new ProductListDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }

    public async Task<ProductDetailDto?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Where(p => p.Id == id)
            .Select(p => new ProductDetailDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CreatedUtc = p.CreatedUtc
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ProductDetailDto> CreateAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CreatedUtc = DateTime.UtcNow
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // Efter SaveChangesAsync har product.Id fått värde av databasen
        return new ProductDetailDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CreatedUtc = product.CreatedUtc
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateProductDto dto)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing == null)
            return false;

        existing.Name = dto.Name;
        existing.Price = dto.Price;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Products.FindAsync(id);
        if (existing == null)
            return false;

        _context.Products.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}