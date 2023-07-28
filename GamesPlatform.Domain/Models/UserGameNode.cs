using System.ComponentModel.DataAnnotations.Schema;

namespace GamesPlatform.Domain.Models
{
    public class UserGameNode
    {
        public Guid Id { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [ForeignKey("GameId")]
        public Guid GameId { get; set; }
        public DateTime TransactionDate { get; set; }

        public UserGameNode(Guid id, Guid userId, Guid gameId)
        {
            Id = id;
            UserId = userId;
            GameId = gameId;
            this.TransactionDate = DateTime.UtcNow;
        }
    }
}
