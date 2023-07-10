using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
    public class UserLibraryService : IUserLibraryService
    {
        private readonly IUserGameNodeRepository _userGameNodeRepository;
        private readonly IMapper _mapper;

        public UserLibraryService(IUserGameNodeRepository userGameNodeRepository, IMapper mapper)
        {
            _userGameNodeRepository = userGameNodeRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<UserGameNodeDto>>> GetAllGamesOfOneUserAsync(Guid userId)
        {
            var nodes = await _userGameNodeRepository.GetAllOfOneUserAsync(userId);

            if (nodes is null)
            {
                return new ServiceResponse<IEnumerable<UserGameNodeDto>>
                {
                    Message = "User games library not found.",
                    IsSuccess = false
                };
            }

            return new ServiceResponse<IEnumerable<UserGameNodeDto>>
            {
                Data = _mapper.Map<IEnumerable<UserGameNode>, IEnumerable<UserGameNodeDto>>(nodes),
                IsSuccess = true
            };
        }

        public async Task AddGameAsync(Guid userId, Guid gameId)
        {
            var nodeCheck = await _userGameNodeRepository.GetNodeAsync(userId, gameId);

            if (nodeCheck is not null) throw new ArgumentException("Game not found.");

            var node = new UserGameNode(userId, gameId);
            await _userGameNodeRepository.CreateAsync(node);
        }

        public async Task DeleteGameAsync(Guid userId, Guid gameId)
        {
            var node = await _userGameNodeRepository.GetNodeAsync(userId, gameId)
                ?? throw new ArgumentException("Game not found.");

            await _userGameNodeRepository.DeleteAsync(userId, gameId);
        }
    }
}
