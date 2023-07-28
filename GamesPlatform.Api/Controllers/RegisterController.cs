using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public RegisterController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
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
