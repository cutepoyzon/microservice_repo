using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IService
{

    public interface IProductService
    {
        Task<ServiceResponseDto?> GetAllProductsAsync();
        Task<ServiceResponseDto?> GetProductByIdAsync(int productId);
        Task<ServiceResponseDto?> CreateProductAsync(ProductDto productDto);
        Task<ServiceResponseDto?> UpdateProductAsync(ProductDto productDto);
        Task<ServiceResponseDto?> DeleteProductAsync(int productId);
    }
}
