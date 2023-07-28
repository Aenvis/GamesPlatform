using GamesPlatform.Domain.Models;

namespace GamesPlatform.Domain.Repositories
{
    public interface IGameRepository
    {
        Task<Game?> GetAsync(Guid id);
        Task<Game?> GetAsync(string title);
        Task<IEnumerable<Game>> GetAllAsync();
        Task<IEnumerable<Game>> GetAllOfOneAuthorAsync(string author);
        Task CreateAsync(Game game);
        Task UpdateAsync(Game game);
        Task DeleteAsync(Guid id);
    }
}