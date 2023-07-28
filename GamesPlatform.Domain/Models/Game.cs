namespace GamesPlatform.Domain.Models
{
    public class Game
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Author { get; protected set; }
        public string? Description { get; protected set; }
		public DateTime CreatedAt { get; protected set; }
		public DateTime UpdatedAt { get; protected set; }

		public Game(Guid id, string title, string author, string? description = null)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
