using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GamesPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMemoryCache _cache;
        private readonly CommandDispatcher _commandDispatcher;

        public LoginController(IMemoryCache cache, CommandDispatcher dispatcher)
        {
            _cache = cache;
            _commandDispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginCommand request)
        {
            request.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(request);
            var jwt = _cache.GetJwt(request.TokenId);

            return Ok(jwt);
        }
    }
}
