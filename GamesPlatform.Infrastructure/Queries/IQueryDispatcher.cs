using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace GamesPlatform.Infrastructure.Queries
{
	public interface IQueryDispatcher
	{
		Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
	}
}
