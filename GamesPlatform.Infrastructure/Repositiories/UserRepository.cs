using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.Repositiories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetAsync(Guid id)
        => await _context.Users.SingleOrDefaultAsync(x => x.Id == id);


        public async Task<User?> GetAsync(string email)
        => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);


        public async Task<IEnumerable<User>> GetAllAsync()
        => await _context.Users.ToListAsync();


        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
			try
			{
				// Code that attempts to save changes to the database using Entity Framework
			await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				// Check for inner exception and handle the error accordingly
				if (ex.InnerException != null)
				{
					// Log or display the inner exception message
					Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
				}
				else
				{
					// Log or display the original exception message
					Console.WriteLine("Exception: " + ex.Message);
				}
			}
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var userToDelete = await GetAsync(id);
            _context.Users.Remove(userToDelete!);
            await _context.SaveChangesAsync();
        }
    }
}