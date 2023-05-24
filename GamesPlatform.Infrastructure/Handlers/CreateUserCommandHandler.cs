using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GamesPlatform.Infrastructure.Handlers
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();    
        }
        public async Task HandleAsync(CreateUserCommand command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, command.DateOfBirth);
        }
    }
}
