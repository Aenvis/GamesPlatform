namespace GamesPlatform.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string? Fullname { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public Localization? Localization { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User(string email, string password, string salt, string username, DateTime dateOfBirth)
        {
            Email = email;
            Password = password;
            Salt = salt;
            Username = username;
            DateOfBirth = dateOfBirth;
            CreatedAt = DateTime.UtcNow;
        }


    }
}