using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IUserLibraryService : IService
    {
        Task<ServiceResponse<IEnumerable<UserGameNodeDto>>> GetAllGamesOfOneUserAsync(Guid userId);
        Task AddGameAsync(Guid userId, Guid gameId);
        Task DeleteGameAsync(Guid userId, Guid gameId);
    }
}
