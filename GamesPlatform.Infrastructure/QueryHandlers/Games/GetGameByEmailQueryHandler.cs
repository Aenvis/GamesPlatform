using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.Games;
using GamesPlatform.Infrastructure.QueryHandlers.Users;
using GamesPlatform.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.QueryHandlers.Games
{
	public class GetGameByEmailQueryHandler : IQueryHandler<GetGameByEmailQuery, GameDto>
	{
		private readonly IGameService _gameService;

		public GetGameByEmailQueryHandler(IGameService gameService)
		{
			_gameService = gameService;
		}

		public async Task<GameDto> HandleAsync(GetGameByEmailQuery query)
		{
			var response = await _gameService.GetGameAsync(query.Title);

			if (!response.IsSuccess)
			{
				throw new Exception(response.Message);
			}

			return response.Data!;
		}
	}
}
