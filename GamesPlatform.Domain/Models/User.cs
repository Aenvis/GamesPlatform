namespace GamesPlatform.Domain.Models
{
	public class User
	{
		public Guid Id { get; protected set; }
		public string Email { get; protected set; }
		public string Password { get; protected set; }
		public string Salt { get; protected set; }
		public string Username { get; protected set; }
		public string Role { get; protected set; }
		public string? Team { get; protected set; }
		public string? Fullname { get; protected set; }
		public DateTime CreatedAt { get; protected set; }
		public DateTime UpdatedAt { get; protected set; }

		public User(Guid id, string email, string password, string salt, string username, string role)
		{
			Id = id;
			Email = email;
			Password = password;
			Salt = salt;
			Username = username;
			Role = role;
			CreatedAt = DateTime.UtcNow;
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetPassword(string newPassword)
		{
			Password = newPassword;
			UpdatedAt = DateTime.UtcNow;
		}

		public void SetSalt(string salt)
		{
			Salt = salt;
			UpdatedAt = DateTime.UtcNow;
		}
	}
}