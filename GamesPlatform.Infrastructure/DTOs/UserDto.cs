using GamesPlatform.Domain.Models;

namespace GamesPlatform.Infrastructure.DTOs
{
    public record UserDto(Guid Id, string Email, string Username, string? FullName, DateTime DateOfBirth);
}