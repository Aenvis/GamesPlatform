using GamesPlatform.Domain.Models;

namespace GamesPlatform.Infrastructure.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; } 
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }  
        public Localization? Localization { get; set; }   
    }
}