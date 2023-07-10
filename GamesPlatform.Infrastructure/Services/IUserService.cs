using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<ServiceResponse<UserDto>> GetUserAsync(string email);
        Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task RegisterAsync(Guid id, string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task DeleteAsync(string email);
    }
}