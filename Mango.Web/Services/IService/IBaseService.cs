using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IService
{
    public interface IBaseService
    {
        Task<ServiceResponseDto?> SendAsync(RequestDto requestDto, bool withBearerToken = true);
    }
}
