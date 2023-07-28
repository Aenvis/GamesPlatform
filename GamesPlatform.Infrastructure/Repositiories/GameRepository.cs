using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.Repositiories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameDbContext _context;

        public GameRepository(GameDbContext context)
        {
            _context = context;
        }

        public async Task<Game?> GetAsync(Guid id)
        => await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Game?> GetAsync(string title)
        => await _context.Games.FirstOrDefaultAsync(x => x.Title == title);

        public async Task<IEnumerable<Game>> GetAllAsync()
        => await _context.Games.ToListAsync();

        public async Task<IEnumerable<Game>> GetAllOfOneAuthorAsync(string author)
        => await _context.Games.Where(x => x.Author == author).ToListAsync();

        public async Task CreateAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var gameToDelete = await GetAsync(id);

            if (gameToDelete is null) return;

            _context.Games.Remove(gameToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
