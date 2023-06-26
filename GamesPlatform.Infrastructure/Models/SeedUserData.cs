using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GamesPlatform.Infrastructure.Models
{
    public static class SeedUserData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new UserContext(serviceProvider.GetRequiredService<
                    DbContextOptions<UserContext>>());

            if (context.Users.Any()) return;

            context.Users.AddRange(
                new User(Guid.NewGuid(), "email1@email.com", "secret1", "salt", "SweetJack69", new DateTime(1988, 12, 25)),
                new User(Guid.NewGuid(), "email2@email.com", "secret2", "salt", "xxGamerxx", new DateTime(2003, 11, 13)),
                new User(Guid.NewGuid(), "email3@email.com", "secret3", "salt", "MarioFromPolandPL", new DateTime(1975, 01, 01)),
                new User(Guid.NewGuid(), "email4@email.com", "secret4", "salt", "KittyPlayGamesXD", new DateTime(2004, 05, 01)),
                new User(Guid.NewGuid(), "email5@email.com", "secret5", "salt", "CatsOverDogs", new DateTime(2000, 03, 03)),
                new User(Guid.NewGuid(), "email6@email.com", "secret6", "salt", "KurtCombine", new DateTime(1997, 04, 01))
                );

            context.SaveChanges();
        }
    }
}
