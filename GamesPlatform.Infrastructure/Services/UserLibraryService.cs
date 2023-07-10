using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.Services
{
    public class UserLibraryService : IUserLibraryService
    {
        public Task<ServiceResponse<IEnumerable<UserGameNodeDto>>> GetAllGamesOfOneUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddGameAsync(Guid userId, Guid gameId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameAsync(Guid userId, Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}
