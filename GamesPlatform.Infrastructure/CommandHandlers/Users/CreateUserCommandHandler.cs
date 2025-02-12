﻿using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Infrastructure.Handlers.Users
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUserCommand command)
        {
            await _userService.RegisterAsync(Guid.NewGuid(), command.Email, command.Username, command.Password, command.Role);
        }
    }
}
