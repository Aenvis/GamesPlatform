namespace GamesPlatform.Infrastructure.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string? FullName { get; set; }

        public UserDto(Guid id, string email, string role, string username, string? fullName)
        {
            Id = id;
            Email = email;
            Role = role;
            Username = username;
            FullName = fullName;
        }
    }
}