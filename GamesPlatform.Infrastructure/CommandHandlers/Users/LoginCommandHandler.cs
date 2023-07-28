using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Extensions;
using GamesPlatform.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace GamesPlatform.Infrastructure.Handlers.Users
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginCommandHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = memoryCache;
        }

        public async Task HandleAsync(LoginCommand command)
        {
            await _userService.LoginAsync(command.Email, command.Password);
            var user = (await _userService.GetUserAsync(command.Email)).Data;

            var token = _jwtHandler.CreateToken(user.Email, user.Role);

            _cache.SetJwt(command.TokenId, token);
        }
    }
}
