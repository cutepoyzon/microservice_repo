using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Services.IService
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var client = _httpClientFactory.CreateClient("Products");
            var httpClientResponse = await client.GetAsync($"/api/products");
            var httpClientResponseContent = await httpClientResponse.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ServiceResponseDto>(httpClientResponseContent);
            if (response.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDto>>(Convert.ToString(response.Result));
            }
            return new List<ProductDto>();  
        }
    }
}
