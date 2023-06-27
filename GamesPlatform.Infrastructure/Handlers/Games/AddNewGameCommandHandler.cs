using GamesPlatform.Infrastructure.Commands;
using GamesPlatform.Infrastructure.Commands.Games;
using GamesPlatform.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesPlatform.Infrastructure.Handlers.Games
{
    public class AddNewGameCommandHandler : ICommandHandler<AddNewGameCommand>
    {
        private readonly IGameService _gameService;

        public AddNewGameCommandHandler(IGameService gameService)
        {
            _gameService = gameService;
        }
        public async Task HandleAsync(AddNewGameCommand command)
        {
            await _gameService.AddNewGameAsync(Guid.NewGuid(), command.Title, command.Author, command.Description);
        }
    }
}
