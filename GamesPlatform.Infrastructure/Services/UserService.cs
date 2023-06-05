using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GamesPlatform.Infrastructure.Services
{
    //TODO: Add ServiceResponse and handle status codes in Controller
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
         
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<UserDto> GetUserAsync(string email)
        {
           var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user); 
        }
        
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task RegisterAsync(Guid id, string email, string username, string password, DateTime dateOfBirth)
        {
            // TODO: change way of error handling
            ValidateNewUser(email, dateOfBirth);

            var newUser = await _userRepository.GetAsync(email);
            if(newUser is not null)
            {
                throw new Exception($"User with given email: {email} already exists.");
            }

            var user = new User(id, email, password, "salt", username, dateOfBirth);
            
            await _userRepository.CreateAsync(user);
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        private void ValidateNewUser(string email, DateTime dateOfBirth)
        {
            if (!IsValidEmail(email))             throw new Exception($"Invalid email: {email}");
            if (!IsValidDateOfBirth(dateOfBirth)) throw new Exception($"You have to be above 13 years old to register.");
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }

        private bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            var dt = dateOfBirth.AddYears(13);

            return DateTime.Today.Date > dt.Date;
        }
    }
}