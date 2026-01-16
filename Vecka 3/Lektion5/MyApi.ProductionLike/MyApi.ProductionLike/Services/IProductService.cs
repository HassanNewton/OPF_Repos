using MyApi.ProductionLike.DTOs;

namespace MyApi.ProductionLike.Services;

// DIP i praktiken:
// Controllern ska bero på detta interface (abstraktion),
// inte på en konkret ProductService och inte på DbContext.
//
// Service-lagret ansvarar för:
// - affärslogik
// - dataåtkomst
// - projection (Select) till DTOs
public interface IProductService
{
    Task<List<ProductListDto>> GetAllAsync();
    Task<ProductDetailDto?> GetByIdAsync(int id);

    Task<ProductDetailDto> CreateAsync(CreateProductDto dto);

    // returnerar false om produkten inte finns
    Task<bool> UpdateAsync(int id, UpdateProductDto dto);

    // returnerar false om produkten inte finns
    Task<bool> DeleteAsync(int id);
}