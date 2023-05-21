using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UsersController(IServiceProvider serviceProvider)
        {
            _userService = (IUserService)serviceProvider.GetRequiredService(typeof(IUserService));    
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            return Ok(await _userService.GetAsync(email));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDto request)
        {
            var newUser = new User(request.Email, request.Password, "salt", request.Username, request.DateOfBirth);
            
            return Created($"users/{request.Email}", null);
        }
    }
}