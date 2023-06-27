using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IGameService : IService
    {
        Task<ServiceResponse<GameDto>> GetGameAsync(string title);
        Task<ServiceResponse<IEnumerable<GameDto>>> GetAllGamesAsync();
        Task AddNewGame(Guid id, string Title, string Author, string? Description = null);
    }
}
