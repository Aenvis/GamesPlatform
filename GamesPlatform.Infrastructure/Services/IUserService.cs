using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task RegisterAsync(Guid id, string email, string username, string password, DateTime dateOfBirth);
        Task LoginAsync(string email, string password);
    }
}