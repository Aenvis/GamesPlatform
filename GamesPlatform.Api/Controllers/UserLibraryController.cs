using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.UsersLibraries;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.UsersLibraries;
using GamesPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
	[Route("api/Users/UserLibrary")]
	[ApiController]
	public class UserLibraryController : ControllerBase
	{
		private readonly IUserLibraryService _userLibraryService;
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryDispatcher _queryDispatcher;

		public UserLibraryController(IUserLibraryService userLibraryService,
									 ICommandDispatcher commandDispatcher,
									 IQueryDispatcher queryDispatcher)
		{
			_userLibraryService = userLibraryService;
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] BrowseUserLibraryQuery query)
		{
			IEnumerable<GameDto> userLibrary;
			try
			{
				userLibrary = await _queryDispatcher.DispatchAsync<BrowseUserLibraryQuery, IEnumerable<GameDto>>(query);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok(userLibrary);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] AddUserGameNodeCommand command)
		{
			try
			{
				await _commandDispatcher.DispatchAsync(command);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Created($"UserLibrary/{command.UserId}", null);
		}

	}
}
