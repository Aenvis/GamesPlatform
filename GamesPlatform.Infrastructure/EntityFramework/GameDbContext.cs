using GamesPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.EntityFramework
{
    public class GameDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
            
        }
    }
}
