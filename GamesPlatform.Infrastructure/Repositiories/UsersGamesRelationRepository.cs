using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.Repositiories
{
    public class UsersGamesRelationRepository : IUserGameNodeRepository
    {
        private readonly UserGameNodeDbContext _context;

        public async Task<UserGameNode?> GetNodeAsync(Guid userId, Guid gameId)
        => await _context.userGameNodes.SingleOrDefaultAsync(x => (x.UserId == userId && x.GameId == gameId));

        public async Task<IEnumerable<UserGameNode>> GetAllOfOneUserAsync(Guid userId)
        => await _context.userGameNodes.ToListAsync();

        public async Task CreateAsync(UserGameNode node)
        {
            await _context.userGameNodes.AddAsync(node);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId, Guid gameId)
        {
            var node = await GetNodeAsync(userId, gameId);
            _context.userGameNodes.Remove(node!);
            await _context.SaveChangesAsync();
        }
    }
}
