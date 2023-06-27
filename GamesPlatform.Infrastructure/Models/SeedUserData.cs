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
            using var context = new UserDbContext(serviceProvider.GetRequiredService<
                    DbContextOptions<UserDbContext>>());

            if (context.Users.Any()) return;

            context.Users.AddRange(
                new User(Guid.NewGuid(), "email1@email.com", "secret1", "salt", "SweetJack69"),
                new User(Guid.NewGuid(), "email2@email.com", "secret2", "salt", "xxGamerxx"),
                new User(Guid.NewGuid(), "email3@email.com", "secret3", "salt", "MarioFromPolandPL"),
                new User(Guid.NewGuid(), "email4@email.com", "secret4", "salt", "KittyPlayGamesXD"),
                new User(Guid.NewGuid(), "email5@email.com", "secret5", "salt", "CatsOverDogs"),
                new User(Guid.NewGuid(), "email6@email.com", "secret6", "salt", "KurtCombine")
                );

            context.SaveChanges();
        }
    }
}
