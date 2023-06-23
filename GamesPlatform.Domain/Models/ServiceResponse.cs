namespace GamesPlatform.Domain.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; } = String.Empty;
    }

    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; } = String.Empty;
    }
}