namespace GamesPlatform.Domain.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string Fullname { get; protected set; }
    }
}