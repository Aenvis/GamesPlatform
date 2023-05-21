using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GamesPlatform.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = (IUserRepository)serviceProvider.GetRequiredService(typeof(IUserRepository));
        }

        public async Task<User> GetAsync(string email)
        {
           return await _userRepository.GetAsync(email);
        }
        
        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(Guid id, string email, string username, string password, DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}