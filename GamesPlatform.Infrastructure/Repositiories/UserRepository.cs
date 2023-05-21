using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;

namespace GamesPlatform.Infrastructure.Repositiories
{
    public class UserRepository : IUserRepository
    {
        private IList<User> _users;
        public IEnumerable<User> Users => _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User("user1@email.com", "password", "salt", "User1", new DateTime(2002, 1, 1))
            };
        }

        public async Task<User> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(string email)
        {
            var user = _users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                throw new Exception($"User with email: {email} is not registered.");
            }

            return user; 
        }

        public async Task<IEnumerable<User>> GetAllAsync() => Users;

        public async Task CreateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
        
        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}