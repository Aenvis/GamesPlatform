using Microsoft.Extensions.DependencyInjection;

namespace GamesPlatform.Infrastructure.Queries
{
	public class QueryDispatcher : IQueryDispatcher
	{
		private readonly IServiceProvider _serviceProvider;

		public QueryDispatcher(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
		{
			if(query is null)
			{
				throw new ArgumentNullException(nameof(query), $"{typeof(TQuery).Name} cannot be null.");
			}

			var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

			return await handler.HandleAsync(query);
		}
	}
}
