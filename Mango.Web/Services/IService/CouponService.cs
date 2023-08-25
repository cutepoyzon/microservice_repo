using Mango.Web.Models.Dto;
using Mango.Web.Utility;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Services.IService
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ServiceResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupons"
            });
        }

        public async Task<ServiceResponseDto?> GetCouponByIdAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupons/" + couponId
            });
        }

        public async Task<ServiceResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupons/GetByCode/" + couponCode
            });
        }

        public async Task<ServiceResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = couponDto,
                Url = StaticDetails.CouponAPIBase + "/api/coupons"
            });
        }

        public async Task<ServiceResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = StaticDetails.CouponAPIBase + "/api/coupons"
            });
        }

        public async Task<ServiceResponseDto?> DeleteCouponAsync(int couponId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = StaticDetails.CouponAPIBase + "/api/coupons/" + couponId
            });
        }

    }
}
