using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Queries.Games
{
	public class GetGameByEmailQuery : IQuery<GameDto>
	{
		public string Title { get; set; }
	}
}
