using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Games;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.Games;
using GamesPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

		public GamesController(IGameService gameService, ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
		{
			_gameService = gameService;
			_commandDispatcher = commandDispatcher;
			_queryDispatcher = queryDispatcher;
		}

		[HttpGet("Game")]
        public async Task<IActionResult> Get([FromQuery] GetGameByEmailQuery query)
        {
            GameDto game;

            try
            {
                game = await _queryDispatcher.DispatchAsync<GetGameByEmailQuery, GameDto>(query);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok(game);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var response = await _gameService.GetAllGamesAsync();

            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddNewGameCommand request)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Created($"Games/{request.Title}", null);
        }
    }
}
