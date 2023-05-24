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
        public async Task<ActionResult<UserDto>> Get(string email)
        {
            return Ok(await _userService.GetAsync(email));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand request)
        {
            await _commandDispatcher.DispatchAsync(request);
            
            return Created($"users/{request.Email}", null);
        }
    }
}