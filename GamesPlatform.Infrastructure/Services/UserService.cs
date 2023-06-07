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

        public async Task<ServiceResponse<UserDto>> GetUserAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            if (user is null) 
            {
                return new ServiceResponse<UserDto>
                {
                    Message = "User not found.",
                    IsSuccess = false
                };
            }
            return new ServiceResponse<UserDto>
            { 
                Data = _mapper.Map<User, UserDto>(user),
                IsSuccess = true
            };
        }

        public async Task<ServiceResponse<IEnumerable<UserDto>>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return new ServiceResponse<IEnumerable<UserDto>>
            {
                Data = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users),
                IsSuccess = true
            };
        }

        public async Task RegisterAsync(Guid id, string email, string username, string password, DateTime dateOfBirth)
        {
            var newUser = await _userRepository.GetAsync(email);
            
            if(newUser is not null)
            {
                throw new Exception($"User with given email {email} already exists.");
            }

            //TODO: Add salt and password hashing
            var user = new User(id, email, password, "salt", username, dateOfBirth);
            await _userRepository.CreateAsync(user);
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}