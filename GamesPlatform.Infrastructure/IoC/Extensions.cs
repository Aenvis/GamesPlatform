using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GamesPlatform.Infrastructure.IoC
{
    public static class Extensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(a => a.Name.EndsWith("Handler") && !a.IsAbstract && !a.IsInterface)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            return services;
        }
    }
}
