using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IGameService : IService
    {
        Task<ServiceResponse<GameDto>> GetGameAsync(string title);
    }
}
