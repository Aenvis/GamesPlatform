using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

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
            // TODO: validate arguments and implement response class
            return Task.CompletedTask;
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
        private bool IsValidEmail(string email)
        {
            var emailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            var dt = dateOfBirth.AddYears(13);

            return dt.Date > dateOfBirth.Date ? false : true;
        }
    }
}