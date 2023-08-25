namespace Mango.Services.ProductsAPI.Models.Dto
{
    public class ServiceResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; } = default;
    }
}
