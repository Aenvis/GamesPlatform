using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using GamesPlatform.Infrastructure.Services;
using GamesPlatform.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using GamesPlatform.Infrastructure.Commands.Users;

namespace GamesPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        
        public UsersController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();  
            _commandDispatcher = serviceProvider.GetRequiredService<ICommandDispatcher>();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            return Ok(await _userService.GetAsync(email));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            await _commandDispatcher.DispatchAsync(request);
            
            return Created($"users/{request.Email}", null);
        }
    }
}