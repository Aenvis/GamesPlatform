﻿using GamesPlatform.Infrastructure.Consts;

namespace GamesPlatform.Infrastructure.Commands.Users
{
    public class CreateUserCommand : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; } = Roles.User;
    }
}
