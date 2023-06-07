using GamesPlatform.Domain.Models;
using System.ComponentModel;

namespace GamesPlatform.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
