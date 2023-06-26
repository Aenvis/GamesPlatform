namespace GamesPlatform.Infrastructure.DTOs
{
    public record UserDto(Guid Id, string Email, string Role, string Username, string? FullName, DateTime DateOfBirth);
}