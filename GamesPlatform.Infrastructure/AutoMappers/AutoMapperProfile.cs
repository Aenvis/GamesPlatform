using AutoMapper;
using GamesPlatform.Domain.Models;
using GamesPlatform.Infrastructure.DTOs;

namespace GamesPlatform.Infrastructure.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<IEnumerable<UserDto>, IEnumerable<User>>();
            
            CreateMap<Game, GameDto>();
            CreateMap<IEnumerable<GameDto>, IEnumerable<Game>>();
            
            CreateMap<UserGameNode, UserGameNodeDto>();
            CreateMap<IEnumerable<UserGameNodeDto>, IEnumerable<UserGameNode>>();
        }
    }
}
