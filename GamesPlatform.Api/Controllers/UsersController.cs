using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IJwtHandler _jwtHandler;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher, IJwtHandler jwtHandler)
        {
            _userService = userService;
            _commandDispatcher = commandDispatcher;
            _jwtHandler = jwtHandler;
        }

        [HttpGet("token")]
        public IActionResult Get()
        {
            var token = _jwtHandler.CreateToken("test@test.test", "user");

            return Ok(token);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            var response = await _userService.GetUserAsync(email);

            if (!response.IsSuccess) return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var response = await _userService.GetAllUsersAsync();

            if (!response.IsSuccess) return NotFound(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Created($"users/{request.Username}", null);
        }


    }
}