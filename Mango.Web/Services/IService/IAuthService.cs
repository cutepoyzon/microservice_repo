using Mango.Web.Models.Dto;

namespace Mango.Web.Services.IService
{
    public interface IAuthService
    {
        Task<ServiceResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ServiceResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
        Task<ServiceResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
    }
}
