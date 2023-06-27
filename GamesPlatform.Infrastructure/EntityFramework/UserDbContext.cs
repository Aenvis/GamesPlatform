using GamesPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.EntityFramework
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }
    }
}
