using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.Queries.Users
{
	public class GetUserByEmailQuery : IQuery<UserDto>
	{
		public string Email { get; set; }
	}
}
