namespace GamesPlatform.Infrastructure.DTOs
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }

        public GameDto(Guid id, string title, string author, string? description)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
        }
    }
}
