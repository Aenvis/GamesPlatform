using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.Consts;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<ServiceResponse<UserDto>> GetUserAsync(string email);
        Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync();
        Task RegisterAsync(Guid id, string email, string username, string password, string role = Roles.User);
        Task LoginAsync(string email, string password);
        Task ChangeUserPasswordAsync(string email, string newPassword);
        Task DeleteAsync(string email);
    }
}