﻿using GamesPlatform.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesPlatform.Infrastructure.EntityFramework
{
    public class UserGameNodeDbContext : DbContext
    {
        public DbSet<UserGameNode> userGameNodes { get; set; }

        public UserGameNodeDbContext(DbContextOptions<UserGameNodeDbContext> options)
            : base(options)
        {
        }
    }
}
