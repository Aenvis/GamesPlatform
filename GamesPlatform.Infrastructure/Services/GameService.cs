using AutoMapper;
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
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GameDto>> GetGameAsync(string title)
        {
            var game = await _gameRepository.GetAsync(title);

            if(game is null)
            {
                return new ServiceResponse<GameDto>
                {
                    IsSuccess = false,
                    Message = "Game not found."
                };
            }

            return new ServiceResponse<GameDto>
            {
                Data = _mapper.Map<Game, GameDto>(game),
                IsSuccess = true
            };
        }
        public async Task<ServiceResponse<IEnumerable<GameDto>>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllAsync();

            if (games is null)
            {
                return new ServiceResponse<IEnumerable<GameDto>>
                {
                    IsSuccess = false,
                    Message = "Games list not found."
                };
            }

            return new ServiceResponse<IEnumerable<GameDto>>
            {
                Data = _mapper.Map<IEnumerable<Game>, IEnumerable<GameDto>>(games),
                IsSuccess = true
            };
        }

        public async Task AddNewGameAsync(Guid id, string title, string author, string? description = null)
        {
            var game = new Game(id, title, author, description);
            await _gameRepository.CreateAsync(game);
        }
    }
}
