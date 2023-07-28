using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Queries.UsersLibraries
{
	public class BrowseUserLibraryQuery : IQuery<IEnumerable<GameDto>>
	{
		public Guid UserId { get; set; }
	}
}
