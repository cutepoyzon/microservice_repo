using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IService
{
    public interface ICouponService
    {
        Task<ServiceResponseDto?> GetAllCouponsAsync();
        Task<ServiceResponseDto?> GetCouponByIdAsync(int couponId);
        Task<ServiceResponseDto?> GetCouponByCodeAsync(string couponCode);
        Task<ServiceResponseDto?> CreateCouponAsync(CouponDto couponDto);
        Task<ServiceResponseDto?> UpdateCouponAsync(CouponDto couponDto);
        Task<ServiceResponseDto?> DeleteCouponAsync(int couponId);
    }
}
