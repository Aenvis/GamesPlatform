using Microsoft.Extensions.DependencyInjection;

namespace GamesPlatform.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {

            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command), $"{typeof(T).Name} cannot be null.");
            }

            var handler = _serviceProvider.GetRequiredService<ICommandHandler<T>>();

            await handler.HandleAsync(command);
        }
    }
}
