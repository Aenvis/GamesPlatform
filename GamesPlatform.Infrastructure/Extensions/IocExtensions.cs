using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GamesPlatform.Infrastructure.Extensions
{
    public static class IocExtensions
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(a => a.Name.EndsWith("CommandHandler") && !a.IsAbstract && !a.IsInterface)
                .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                .ToList()
                .ForEach(typesToRegister =>
                {
                    typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
                });

            return services;
        }

		public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
		{
			Assembly.GetExecutingAssembly()
				.GetTypes()
				.Where(a => a.Name.EndsWith("QueryHandler") && !a.IsAbstract && !a.IsInterface)
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
