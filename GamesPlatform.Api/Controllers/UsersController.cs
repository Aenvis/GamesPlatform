using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.Users;
using GamesPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly ICommandDispatcher _commandDispatcher;
		private readonly IQueryDispatcher _queryDispatcher;

		public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
		{
			_userService = userService;
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;

		}

		[HttpGet("User")]
		public async Task<IActionResult> Get([FromQuery] GetUserByEmailQuery query)
		{
			UserDto user;
			try
			{
				user = await _queryDispatcher.DispatchAsync<GetUserByEmailQuery, UserDto>(query);
			}
			catch (Exception e)
			{
				return NotFound(e.Message);
			}

			return Ok(user);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
		{
			var response = await _userService.GetAllUsersAsync();

			if (!response.IsSuccess) return NotFound(response.Message);

			return Ok(response.Data);
		}

		[HttpDelete("delete")]
		[Authorize(Policy = "admin")]
		public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
		{
			try
			{
				await _commandDispatcher.DispatchAsync(command);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}

			return Ok($"User using email {command.Email} has been deleted succesfully.");
		}
	}
}