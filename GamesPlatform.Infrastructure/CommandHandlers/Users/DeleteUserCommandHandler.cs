using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Infrastructure.CommandHandlers.Users
{
	public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
	{
		private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
				_userService = userService;
        }
		
        public async Task HandleAsync(DeleteUserCommand command)
		=> await _userService.DeleteAsync(command.Email);
		
	}
}
