using GamesPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.EntityFramework
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
    }
}
