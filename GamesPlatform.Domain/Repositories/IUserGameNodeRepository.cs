using GamesPlatform.Domain.Models;

namespace GamesPlatform.Domain.Repositories
{
    public interface IUserGameNodeRepository
    {
        Task<UserGameNode?> GetNodeAsync(Guid userId, Guid gameId);
        Task<IEnumerable<UserGameNode>> GetAllOfOneUserAsync(Guid userId);
        Task CreateAsync(UserGameNode node);
        Task DeleteAsync(Guid userId, Guid gameId);
    }
}
