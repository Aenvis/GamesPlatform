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
                new User(Guid.NewGuid(), "user1@email.com", "password", "salt", "User1", new DateTime(2002, 1, 1))
            };
        }

        public async Task<User> GetAsync(Guid id)
        {
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public async Task<User> GetAsync(string email)
        {
            return _users.SingleOrDefault(x => x.Email == email);
        }

        public async Task<IEnumerable<User>> GetAllAsync() => Users;

        public async Task CreateAsync(User user)
        {
            _users.Add(user);
        }

        public async Task UpdateAsync(User user)
        {
            //update user
            await Task.CompletedTask;
        }
        
        public async Task DeleteAsync(Guid id)
        {
            var userToDelete = await GetAsync(id);
            _users.Remove(userToDelete);
        }
    }
}