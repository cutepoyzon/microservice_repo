using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IService
{
    public interface ICartService
    {
        Task<ServiceResponseDto?> GetCartByUserIdAsync(string userId);
        Task<ServiceResponseDto?> UpsertCartAsync(CartDto cartDto);
        Task<ServiceResponseDto?> RemoveCartItemAsync(int cartDetailsId);
        Task<ServiceResponseDto?> ApplyCouponAsync(CartDto cartDto);
    }
}
