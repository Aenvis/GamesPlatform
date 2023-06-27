using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task<ServiceResponse<GameDto>> GetGameAsync(string title)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<IEnumerable<GameDto>>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddNewGame(Guid id, string Title, string Author, string? Description = null)
        {
            throw new NotImplementedException();
        }
    }
}
