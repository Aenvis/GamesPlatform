using System.ComponentModel.DataAnnotations.Schema;

namespace GamesPlatform.Domain.Models
{
    public class UserGameNode
    {
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        [ForeignKey("GameId")]
        public Guid GameId { get; set; }
        public DateTime TransactionDate { get; set; }

        public UserGameNode(Guid userId, Guid gameId)
        {
            UserId = userId;
            GameId = gameId;
            this.TransactionDate = DateTime.UtcNow;
        }
    }
}
