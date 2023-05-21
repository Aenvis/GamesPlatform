using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<User> GetAsync(string email);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task RegisterAsync(Guid id, string email, string username, string password, DateTime dateOfBirth);
        Task LoginAsync(string email, string password);
    }
}