using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.UsersLibraries;
using GamesPlatform.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.QueryHandlers.UsersLibraries
{
	public class BrowseUserLibraryQueryHandler : IQueryHandler<BrowseUserLibraryQuery, IEnumerable<GameDto>>
	{
		private readonly IUserLibraryService _userLibraryService;

		public BrowseUserLibraryQueryHandler(IUserLibraryService userLibraryService)
		{
			_userLibraryService = userLibraryService;
		}

		public async Task<IEnumerable<GameDto>> HandleAsync(BrowseUserLibraryQuery query)
		{
			var response = await _userLibraryService.GetAllGamesOfOneUserAsync(query.UserId);

			if (!response.IsSuccess)
			{
				throw new Exception(response.Message);
			}

			return response.Data!;
		}
	}
}
