namespace GamesPlatform.Infrastructure.Queries
{
	public interface IQueryHandler<in TQuery, TResult>
	{
		Task<TResult> HandleAsync(TQuery query);
	}
}
