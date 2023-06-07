using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using GamesPlatform.Infrastructure.Services;
using GamesPlatform.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using GamesPlatform.Infrastructure.Commands.Users;
using System;

namespace GamesPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICommandDispatcher _commandDispatcher;
        
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher)
        {
            _userService = userService;  
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            var response = await _userService.GetUserAsync(email);

            if(!response.IsSuccess) return NotFound(response.Message);
            
            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var allUsers = await _userService.GetAllUsersAsync();

            return Ok(allUsers);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand request)
        {
            await _commandDispatcher.DispatchAsync(request);
            
            return Created($"users/{request.Username}", null);
        }
    }
}