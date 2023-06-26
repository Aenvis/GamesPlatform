using GamesPlatform.Infrastructure.Commands;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
    }
}