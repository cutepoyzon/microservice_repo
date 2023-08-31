using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Services.IService
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupons");
            var httpClientResponse = await client.GetAsync($"/api/coupons/GetByCode/{couponCode}");
            var httpClientResponseContent = await httpClientResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ServiceResponseDto>(httpClientResponseContent);
            if (response.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
            }
            return new CouponDto();
        }
    }
}
