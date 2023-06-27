using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly ICommandDispatcher _commandDispatcher;

        public GamesController(IGameService gameService, ICommandDispatcher commandDispatcher)
        {
            _gameService = gameService;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<GameDto>> Get(string title)
        {
            var response = await _gameService.GetGameAsync(title);

            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var response = await _gameService.GetAllGamesAsync();

            if (!response.IsSuccess) return BadRequest(response.Message);
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task Post()
        {

        }
    }
}
