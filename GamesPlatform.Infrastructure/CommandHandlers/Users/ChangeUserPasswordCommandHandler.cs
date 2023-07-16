using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Users;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Infrastructure.CommandHandlers.Users
{
	public class ChangeUserPasswordCommandHandler : ICommandHandler<ChangeUserPasswordCommand>
	{
		private readonly IUserService _userService;

		public ChangeUserPasswordCommandHandler(IUserService userService)
		{
			_userService = userService;
		}

		public async Task HandleAsync(ChangeUserPasswordCommand command)
		{
			await _userService.LoginAsync(command.Email, command.OldPassword);
			await _userService.ChangeUserPasswordAsync(command.Email, command.NewPassword);
		}
	}
}
