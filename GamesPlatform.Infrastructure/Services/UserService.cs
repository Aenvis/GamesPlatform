using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace GamesPlatform.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
         
        public UserService(IServiceProvider serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<UserDto> GetAsync(string email)
        {
           var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user); 
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