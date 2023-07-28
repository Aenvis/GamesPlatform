using GamesPlatform.Domain.Repositories;
using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.UsersLibraries;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Infrastructure.CommandHandlers.UsersLibraries
{
	public class AddUserGameNodeCommandHandler : ICommandHandler<AddUserGameNodeCommand>
	{
		private readonly IUserLibraryService _userLibraryService;

		public AddUserGameNodeCommandHandler(IUserLibraryService userLibraryService)
		{
			_userLibraryService = userLibraryService;
		}

		public async Task HandleAsync(AddUserGameNodeCommand command)
		{
			await _userLibraryService.AddGameAsync(command.UserId, command.GameId);

		}
	}
}
