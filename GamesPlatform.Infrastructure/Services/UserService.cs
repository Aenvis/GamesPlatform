using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.Consts;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
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

            if (users is null)
            {
                return new ServiceResponse<IEnumerable<UserDto>>
                {
                    Message = "Users list not found.",
                    IsSuccess = false
                };
            }

            return new ServiceResponse<IEnumerable<UserDto>>
            {
                Data = _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users),
                IsSuccess = true
            };
        }

        public async Task RegisterAsync(Guid id, string email, string username, string password, string role = Roles.User)
        {
            var newUser = await _userRepository.GetAsync(email);

            if (newUser is not null)
            {
                throw new ArgumentException($"User with given email: '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt();
            var hash = _encrypter.GetHash(password, salt);
            var user = new User(id, email, hash, salt, username, role);
            await _userRepository.CreateAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email)
                ?? throw new ArgumentException("Invalid email or password.");

            var salt = user.Salt;
            var hash = _encrypter.GetHash(password, salt);

            if (user.Password == hash) return;

            throw new ArgumentException("Invalid email or password.");
        }

        public async Task ChangeUserPasswordAsync(string email, string newPassword)
        {
            var user = await _userRepository.GetAsync(email);

			var salt = _encrypter.GetSalt();
			var hash = _encrypter.GetHash(newPassword, salt);

            user.SetPassword(hash);
            user.SetSalt(salt);

			await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(string email)
        {
            var user = await _userRepository.GetAsync(email)
                ?? throw new ArgumentException("User not found.");

            await _userRepository.DeleteAsync(user.Id);
        }
    }
}