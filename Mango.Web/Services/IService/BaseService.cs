using System.Net;
using System.Text;
using Mango.Web.Models.Dto;
using Newtonsoft.Json;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Services.IService
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<ServiceResponseDto?> SendAsync(RequestDto requestDto, bool withBearerToken = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage requestMessage = new();
                requestMessage.Headers.Add("Accept", "application/json");

                //Add Auth header
                if (withBearerToken)
                {
                    var token = _tokenProvider.GetToken();
                    requestMessage.Headers.Add("Authorization", $"Bearer {token}");
                }

                requestMessage.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                requestMessage.Method = requestDto.ApiType switch
                {
                    ApiType.POST => HttpMethod.Post,
                    ApiType.PUT => HttpMethod.Put,
                    ApiType.PATCH => HttpMethod.Patch,
                    ApiType.DELETE => HttpMethod.Delete,
                    _ => HttpMethod.Get,
                };

                HttpResponseMessage? responseMessage = await client.SendAsync(requestMessage);
                //_ = await client.SendAsync(requestMessage);

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };
                    case HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Forbidden"
                        };
                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized"
                        };
                    case HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internal Server Error"
                        };
                    default:
                        var apiContent = await responseMessage.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ServiceResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var responseDto = new ServiceResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false,
                };
                return responseDto;
            }
        }
    }
}
