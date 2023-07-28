namespace GamesPlatform.Infrastructure.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string? FullName { get; set; }

        public UserDto(Guid id, string email, string username, string role, string? fullName)
        {
            Id = id;
            Email = email;
            Username = username;
            Role = role;
            FullName = fullName;
        }
    }
}