using GamesPlatform.Infrastructure.DTOs;
using GamesPlatform.Infrastructure.Queries;
using GamesPlatform.Infrastructure.Queries.Users;
using GamesPlatform.Infrastructure.Services;

namespace GamesPlatform.Infrastructure.QueryHandlers.Users
{
	public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserDto>
	{
		private readonly IUserService _userService;

        public GetUserByEmailQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> HandleAsync(GetUserByEmailQuery query)
		{
			var response = await _userService.GetUserAsync(query.Email);

			if (!response.IsSuccess)
			{
				throw new Exception(response.Message);
			}

			return response.Data!;
		}
	}
}
