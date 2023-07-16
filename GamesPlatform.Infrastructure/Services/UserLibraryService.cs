using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Services
{
	public class UserLibraryService : IUserLibraryService
	{
		private readonly IUserGameNodeRepository _userGameNodeRepository;
		private readonly IGameService _gameService;
		private readonly IMapper _mapper;

		public UserLibraryService(IUserGameNodeRepository userGameNodeRepository, IMapper mapper, IGameService gameService)
		{
			_userGameNodeRepository = userGameNodeRepository;
			_mapper = mapper;
			_gameService = gameService;
		}

		public async Task<ServiceResponse<IEnumerable<GameDto>>> GetAllGamesOfOneUserAsync(Guid userId)
		{
			var nodes = await _userGameNodeRepository.GetAllOfOneUserAsync(userId);

			if (nodes is null)
			{
				return new ServiceResponse<IEnumerable<GameDto>>
				{
					Message = "User games library not found.",
					IsSuccess = false
				};
			}

			var games = new List<GameDto>();

			foreach (var node in nodes)
			{
				var response = await _gameService.GetGameAsync(node.GameId);

				if (response.IsSuccess)
				{
					games.Add(response.Data!);
				}
			}

			return new ServiceResponse<IEnumerable<GameDto>>
			{
				Data = games,
				IsSuccess = true
			};
		}

		public async Task AddGameAsync(Guid userId, Guid gameId)
		{
			var nodeCheck = await _userGameNodeRepository.GetNodeAsync(userId, gameId);

			if (nodeCheck is not null)
			{
				throw new ArgumentException("The game is already added to the user's library.");
			}

			var node = new UserGameNode(Guid.NewGuid(), userId, gameId);
			await _userGameNodeRepository.CreateAsync(node);
		}

		public async Task DeleteGameAsync(Guid userId, Guid gameId)
		{
			var node = await _userGameNodeRepository.GetNodeAsync(userId, gameId);

			if (node is null)
			{
				throw new ArgumentException("Game not found.");
			}

			await _userGameNodeRepository.DeleteAsync(userId, gameId);
		}
	}
}
